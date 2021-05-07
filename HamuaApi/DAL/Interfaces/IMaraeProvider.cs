using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface IMaraeProvider
    {
        Task<IEnumerable<Marae>> GetAllMaraeAsync(string sortby = "", string searchString = "");

        Task<IEnumerable<Marae>> GetAllOrdersByAreaAsync(string areaName, string sortby = "", string searchString = "");

        Task<IEnumerable<Marae>> GetAllOrdersByHapuAsync(string hapuName, string sortby = "", string searchString = "");

        Task<Marae> GetMaraeByIdAsync(int id);
    }
}