﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAdvert.Api.Services;
using WebAdvert.Api.Services.Dynamodb;

namespace WebAdvert.Api.HealthChecks
{
    public class StorageHealthCheck : IHealthCheck
    {
        private readonly IAdvertStorageService _storageService;

        public StorageHealthCheck(IAdvertStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var isStorageOk = await _storageService.CheckHealthAsync();

            if (isStorageOk)
            {
                return HealthCheckResult.Healthy("The check indicates a healthy result.");
            }
            else
            {
                return HealthCheckResult.Unhealthy("The check indicates an unhealthy result.");
            }
        }
    }
}
