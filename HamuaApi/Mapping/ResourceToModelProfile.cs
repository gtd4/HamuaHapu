using AutoMapper;
using HamuaHapuCommon.Resources;
using HamuaRegistrationApi.DAL.Models;

namespace HamuaRegistrationApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveTangataResource, Tangata>();
            CreateMap<SaveMaraeResource, Marae>();
            CreateMap<SaveTupunaResource, Tupuna>();
        }
    }
}