using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface IMaraeProvider
    {
        IEnumerable<NgaMarae> GetAllOrders();

        IEnumerable<NgaMarae> GetAllOrdersByArea(string areaName);

        IEnumerable<NgaMarae> GetAllOrdersByHapu(string areaName);
    }
}