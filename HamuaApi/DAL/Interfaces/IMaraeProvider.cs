using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface IMaraeProvider
    {
        Task<IEnumerable<NgaMarae>> GetAllMaraeAsync(string sortby = "", string searchString = "");

        Task<IEnumerable<NgaMarae>> GetAllOrdersByAreaAsync(string areaName, string sortby = "", string searchString = "");

        Task<IEnumerable<NgaMarae>> GetAllOrdersByHapuAsync(string hapuName, string sortby = "", string searchString = "");

        Task<NgaMarae> GetMaraeByIdAsync(int id);
    }
}