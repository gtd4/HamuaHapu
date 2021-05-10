using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Services.Implementations
{
    public class TangataService : ITangataService
    {
        public ITangataProvider tangataProvider;

        public TangataService(ITangataProvider provider)
        {
            tangataProvider = provider;
        }

        public Task<Tangata> AddChild(Tangata newTangata, int parentId)
        {
            throw new NotImplementedException();
        }

        public Task<Tangata> CreateTangataAsync(Tangata newTangata, int parentId = 0, int childId = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tangata>> GetAllTangataAsync(string sortby = "", string searchString = "", bool include = false)
        {
            return await tangataProvider.GetAllTangataAsync(sortby, searchString, include);
        }

        public async Task<Tangata> GetTangataByIdAsync(int id, bool include = false)
        {
            return await tangataProvider.GetTangataByIdAsync(id, include);
        }

        public Task<Tangata> UpdateTangataAsync(int id, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}