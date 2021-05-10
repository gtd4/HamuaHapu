﻿using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Services.Interfaces
{
    public interface ITangataService
    {
        Task<IEnumerable<Tangata>> GetAllTangataAsync(string sortby = "", string searchString = "", bool include = false);

        Task<Tangata> GetTangataByIdAsync(int id, bool include = false);

        Task<Tangata> CreateTangataAsync(Tangata newTangata, int parentId = 0, int childId = 0);

        Task<Tangata> AddChild(Tangata newTangata, int parentId);

        Task<Tangata> UpdateTangataAsync(int id, string firstName, string lastName);
    }
}