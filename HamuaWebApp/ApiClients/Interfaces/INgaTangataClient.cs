using HamuaHapuCommon.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuRegistration.ApiClients.Interfaces
{
    public interface INgaTangataClient
    {
        Task<IEnumerable<TangataResource>> GetNgaTangataAsync(string url = "");

        Task<TangataResource> GetTangataByIdAsync(int id);

        //Task<TangataResource> CreateAsync(SaveTangataResource ngaMarae);

        Task<TangataResource> EditAsync(int id, TangataResource ngaMarae);

        Task<IEnumerable<IGrouping<string, TangataResource>>> GetTangataReoProficiency();

        Task<IEnumerable<IGrouping<string, TangataResource>>> GetTangataResidenceCountry();

        Task<IEnumerable<IGrouping<string, TangataResource>>> GetTangataGender();
    }
}