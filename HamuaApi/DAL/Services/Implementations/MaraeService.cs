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
                return new SaveMaraeResponse($"An error occurred when saving the Marae: {ex.Message}");
            }
        }

        public async Task<SaveMaraeResponse> UpdateMaraeAsync(int id, Marae editMarae)
        {
            var existingMarae = await maraeProvider.GetMaraeByIdAsync(id);

            if (existingMarae == null)
                return new SaveMaraeResponse("Marae not found.");

            existingMarae.Name = editMarae.Name;
            existingMarae.Area = editMarae.Area;
            existingMarae.Hapu = editMarae.Hapu;

            try
            {
                maraeProvider.Update(existingMarae);
                await maraeUnitOfWork.CompleteAsync();

                return new SaveMaraeResponse(existingMarae);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveMaraeResponse($"An error occurred when saving the Tangata: {ex.Message}");
            }
        }
    }
}