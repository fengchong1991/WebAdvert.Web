using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdvert.Api.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace WebAdvert.Api.Services
{
    public class DynamoDBAdvertStorage : IAdvertStorageService
    {
        private readonly IMapper _mapper;

        public DynamoDBAdvertStorage(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<string> Add(AdvertModel advertModel)
        {
            var dbModel = _mapper.Map<AdvertDbModel>(advertModel);
            
            dbModel.Id = new Guid().ToString();
            dbModel.CreationDateTime = DateTime.UtcNow;
            dbModel.Status = AdvertStatus.Pending;

            using (var client = new AmazonDynamoDBClient())
            using (var context = new DynamoDBContext(client))
            {
                await context.SaveAsync(dbModel);
            }

            return dbModel.Id;
        }

        public async Task Confirm(ConfirmAdvertModel confirmAdvertModel)
        {
            using (var client = new AmazonDynamoDBClient())
            using (var context = new DynamoDBContext(client))
            {
                var record = await context.LoadAsync<AdvertDbModel>(confirmAdvertModel.Id);
                if (record == null)
                {
                    throw new KeyNotFoundException("key not found");
                }

                if (confirmAdvertModel.Status == AdvertStatus.Active)
                {
                    record.Status = AdvertStatus.Active;
                    await context.SaveAsync(record);
                }
                else
                {
                    await context.DeleteAsync(record);
                }
            }
        }

        public async Task<bool> CheckHealthAsync()
        {
            try
            {
                using (var client = new AmazonDynamoDBClient())
                {
                    var table = await client.DescribeTableAsync("Adverts");
                    return table.Table.TableStatus == "ACTIVE";
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
