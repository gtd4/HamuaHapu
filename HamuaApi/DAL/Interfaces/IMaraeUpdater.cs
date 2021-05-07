using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface IMaraeUpdater
    {
        Task<Marae> CreateMaraeAsync(Marae newMarae);

        Task<Marae> UpdateMaraeAsync(int id, string area, string maraeName, string hapu);

        Task<Marae> DeleteMaraeAsync(int id);
    }
}