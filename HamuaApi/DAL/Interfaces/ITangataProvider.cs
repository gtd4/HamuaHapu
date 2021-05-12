using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface ITangataProvider
    {
        Task<IEnumerable<Tangata>> GetAllTangataAsync(string sortby = "", string searchString = "", bool includeMarae = false, bool includeChildren = false);

        Task<Tangata> GetTangataByIdAsync(int id, bool includeMarae = false, bool includeChildren = false);

        Task AddAsync(Tangata tangata, IEnumerable<int> ngaMarae);

        //Task<IEnumerable<Tangata>> GetAllTangataByAreaAsync(string areaName, string sortby = "", string searchString = "");

        //Task<IEnumerable<Tangata>> GetAllTangataByHapuAsync(string hapuName, string sortby = "", string searchString = "");
    }
}