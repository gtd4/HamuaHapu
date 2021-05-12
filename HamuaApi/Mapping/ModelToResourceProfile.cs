using AutoMapper;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Marae, MaraeResource>();
            CreateMap<Marae, MaraeResourceWithNgaTangata>();
            CreateMap<Tangata, TangataResource>();
            CreateMap<Tangata, TangataResourceWithNgaMarae>();
            CreateMap<Tangata, TangataResourceWithChildren>();
            CreateMap<Tangata, TangataResourceWithNgaMaraeChildren>();
        }
    }
}