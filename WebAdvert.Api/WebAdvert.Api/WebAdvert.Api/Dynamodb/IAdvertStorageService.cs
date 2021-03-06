﻿using System.Threading.Tasks;
using WebAdvert.Api.Models;

namespace WebAdvert.Api.Services.Dynamodb
{
    public interface IAdvertStorageService
    {
        Task<string> Add(AdvertModel advertModel);
        Task Confirm(ConfirmAdvertModel confirmAdvertModel);

        Task<bool> CheckHealthAsync();
    }
}
