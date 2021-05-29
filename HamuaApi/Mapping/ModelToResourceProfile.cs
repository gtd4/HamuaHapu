using AutoMapper;
using HamuaHapuCommon.Resources;
using HamuaRegistrationApi.DAL.Models;

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
            CreateMap<Tupuna, TupunaResource>();
        }
    }
}