using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface IMaraeProvider
    {
        IEnumerable<NgaMarae> GetAllMarae(string sortby = "", string searchString = "");

        IEnumerable<NgaMarae> GetAllOrdersByArea(string areaName, string sortby = "", string searchString = "");

        IEnumerable<NgaMarae> GetAllOrdersByHapu(string hapuName, string sortby = "", string searchString = "");

        NgaMarae GetMaraeById(int id);
    }
}