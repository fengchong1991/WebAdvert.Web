using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebAdvert.Api.Models;

namespace WebAdvert.Api.Services
{
    public class AdvertProfile: Profile
    {
        public AdvertProfile()
        {
            CreateMap<AdvertModel, AdvertDbModel>();
        }
    }
}
