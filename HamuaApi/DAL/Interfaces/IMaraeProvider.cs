using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface IMaraeProvider
    {
        Task<IEnumerable<Marae>> GetAllMaraeAsync(string sortby = "", string searchString = "", bool include = false);

        Task<IEnumerable<Marae>> GetAllMaraeByAreaAsync(string areaName, string sortby = "", string searchString = "", bool include = false);

        Task<IEnumerable<Marae>> GetAllMaraeByHapuAsync(string hapuName, string sortby = "", string searchString = "", bool include = false);

        Task<Marae> GetMaraeByIdAsync(int id, bool include = false);
    }
}