using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdvert.Api.Models;

namespace WebAdvert.Api.Services
{
    public class DynamoDBAdvertStorage : IAdvertStorageService
    {
        public Task<string> Add(AdvertModel advertModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Confirm(ConfirmAdvertModel confirmAdvertModel)
        {
            throw new NotImplementedException();
        }
    }
}
