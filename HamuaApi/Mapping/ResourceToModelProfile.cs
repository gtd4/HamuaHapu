using AutoMapper;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveTangataResource, Tangata>();
            CreateMap<SaveMaraeResource, Marae>();
        }
    }
}