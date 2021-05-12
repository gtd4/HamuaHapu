using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface IMaraeProvider
    {
        Task<IEnumerable<Marae>> GetAllMaraeAsync(string sortby = "", string searchString = "", bool includeTangata = false);

        Task<IEnumerable<Marae>> GetAllMaraeByAreaAsync(string areaName, string sortby = "", string searchString = "", bool includeTangata = false);

        Task<IEnumerable<Marae>> GetAllMaraeByHapuAsync(string hapuName, string sortby = "", string searchString = "", bool includeTangata = false);

        Task<Marae> GetMaraeByIdAsync(int id, bool includeTangata = false);

        Task AddAsync(Marae marae);

        void Update(Marae editMarae);

        void Remove(Marae marae);
    }
}