using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.DAL.Services.Communication;
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
        public IUnitOfWork tangataUnitOfWork;

        public TangataService(ITangataProvider provider, IUnitOfWork unitOfWork)
        {
            tangataProvider = provider;
            tangataUnitOfWork = unitOfWork;
        }

        public Task<Tangata> AddChild(Tangata newTangata, int parentId)
        {
            throw new NotImplementedException();
        }

        public async Task<TangataResponse> CreateTangataAsync(Tangata newTangata, IEnumerable<int> ngaMarae, int parentId = 0, int childId = 0)
        {
            try
            {
                await tangataProvider.AddAsync(newTangata, ngaMarae);
                await tangataUnitOfWork.CompleteAsync();

                return new TangataResponse(newTangata);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TangataResponse($"An error occurred when saving the Tangata: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Tangata>> GetAllTangataAsync(string sortby = "", string searchString = "", bool includeMarae = false, bool includeChildren = false)
        {
            return await tangataProvider.GetAllTangataAsync(sortby, searchString, includeMarae, includeChildren);
        }

        public async Task<Tangata> GetTangataByIdAsync(int id, bool includeMarae = false, bool includeChildren = false)
        {
            return await tangataProvider.GetTangataByIdAsync(id, includeMarae, includeChildren);
        }

        public Task<TangataResponse> UpdateTangataAsync(int id, Tangata editTangata)
        {
            throw new NotImplementedException();
        }
    }
}