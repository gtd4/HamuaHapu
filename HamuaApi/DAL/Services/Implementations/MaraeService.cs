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
    public class MaraeService : IMaraeService
    {
        public IMaraeProvider maraeProvider;
        public IUnitOfWork maraeUnitOfWork;

        public MaraeService(IMaraeProvider provider, IUnitOfWork uow)
        {
            maraeProvider = provider;
            maraeUnitOfWork = uow;
        }

        public async Task<SaveMaraeResponse> CreateMaraeAsync(Marae newMarae)
        {
            try
            {
                await maraeProvider.AddAsync(newMarae);
                await maraeUnitOfWork.CompleteAsync();

                return new SaveMaraeResponse(newMarae);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveMaraeResponse($"An error occurred when saving the Tangata: {ex.Message}");
            }
        }

        public Task<Marae> DeleteMaraeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Marae>> GetAllMaraeAsync(string sortby = "", string searchString = "", bool include = false)
        {
            return await maraeProvider.GetAllMaraeAsync(sortby, searchString, include);
        }

        public async Task<IEnumerable<Marae>> GetAllMaraeByAreaAsync(string areaName, string sortby = "", string searchString = "", bool include = false)
        {
            return await maraeProvider.GetAllMaraeByAreaAsync(areaName, sortby, searchString, include);
        }

        public async Task<IEnumerable<Marae>> GetAllMaraeByHapuAsync(string hapuName, string sortby = "", string searchString = "", bool include = false)
        {
            return await maraeProvider.GetAllMaraeByHapuAsync(hapuName, sortby, searchString, include);
        }

        public async Task<Marae> GetMaraeByIdAsync(int id, bool include = false)
        {
            return await maraeProvider.GetMaraeByIdAsync(id, include);
        }

        public Task<Marae> UpdateMaraeAsync(int id, string area, string maraeName, string hapu)
        {
            throw new NotImplementedException();
        }
    }
}