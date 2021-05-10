using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Services.Implementations
{
    public class MaraeService : IMaraeService
    {
        public IMaraeProvider maraeProvider;

        public MaraeService(IMaraeProvider provider)
        {
            maraeProvider = provider;
        }

        public Task<Marae> CreateMaraeAsync(Marae newMarae)
        {
            throw new NotImplementedException();
        }

        public Task<Marae> DeleteMaraeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Marae>> GetAllMaraeAsync(string sortby = "", string searchString = "", bool include = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Marae>> GetAllMaraeByAreaAsync(string areaName, string sortby = "", string searchString = "", bool include = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Marae>> GetAllMaraeByHapuAsync(string hapuName, string sortby = "", string searchString = "", bool include = false)
        {
            throw new NotImplementedException();
        }

        public Task<Marae> GetMaraeByIdAsync(int id, bool include = false)
        {
            throw new NotImplementedException();
        }

        public Task<Marae> UpdateMaraeAsync(int id, string area, string maraeName, string hapu)
        {
            throw new NotImplementedException();
        }
    }
}