﻿using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface ITangataProvider
    {
        Task<IEnumerable<Tangata>> GetAllTangataAsync(string sortby = "", string searchString = "");

        Task<Tangata> GetTangataByIdAsync(int id);

        //Task<IEnumerable<Tangata>> GetAllTangataByAreaAsync(string areaName, string sortby = "", string searchString = "");

        //Task<IEnumerable<Tangata>> GetAllTangataByHapuAsync(string hapuName, string sortby = "", string searchString = "");
    }
}