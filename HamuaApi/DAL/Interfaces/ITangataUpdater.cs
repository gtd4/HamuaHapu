using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface ITangataUpdater
    {
        Task<Tangata> CreateTangataAsync(Tangata newTangata);

        Task<Tangata> UpdateTangataAsync(int id, string firstName, string lastName);

        //Task<Marae> DeleteTangataAsync(int id);
    }
}