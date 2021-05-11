using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.DAL.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Services.Interfaces
{
    public interface IMaraeService
    {
        Task<IEnumerable<Marae>> GetAllMaraeAsync(string sortby = "", string searchString = "", bool include = false);

        Task<IEnumerable<Marae>> GetAllMaraeByAreaAsync(string areaName, string sortby = "", string searchString = "", bool include = false);

        Task<IEnumerable<Marae>> GetAllMaraeByHapuAsync(string hapuName, string sortby = "", string searchString = "", bool include = false);

        Task<Marae> GetMaraeByIdAsync(int id, bool include = false);

        Task<MaraeResponse> CreateMaraeAsync(Marae newMarae);

        Task<MaraeResponse> UpdateMaraeAsync(int id, Marae editMarae);

        Task<MaraeResponse> DeleteMaraeAsync(int id);
    }
}