using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAdvert.Web.Models.Advert.Requests;
using WebAdvert.Web.Models.Advert.Responses;

namespace WebAdvert.Web.ServiceClient
{
    public class AdvertApiClient : IAdvertApiClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public AdvertApiClient(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;

            var createUrl = _configuration["AdvertApi:CreateUrl"];
            _client.BaseAddress = new Uri(createUrl);
            _client.DefaultRequestHeaders.Add("Content-type", "application/json");
        }

        public async Task<AdvertResponse> Create(CreateAdvertModel model)
        {
            var jsonModel = JsonConvert.SerializeObject(model);
            var response = await _client.PostAsync(_client.BaseAddress, new StringContent(jsonModel));

            var responseJson = await response.Content.ReadAsStringAsync();
            var createAdvertResponse = JsonConvert.DeserializeObject<AdvertResponse>(responseJson);

            return createAdvertResponse;
        }
    }
}
