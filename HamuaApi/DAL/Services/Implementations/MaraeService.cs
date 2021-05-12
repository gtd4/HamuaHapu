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

        public async Task<IEnumerable<Marae>> GetAllMaraeAsync(string sortby = "", string searchString = "", bool includeTangata = false)
        {
            return await maraeProvider.GetAllMaraeAsync(sortby, searchString, includeTangata);
        }

        public async Task<IEnumerable<Marae>> GetAllMaraeByAreaAsync(string areaName, string sortby = "", string searchString = "", bool includeTangata = false)
        {
            return await maraeProvider.GetAllMaraeByAreaAsync(areaName, sortby, searchString, includeTangata);
        }

        public async Task<IEnumerable<Marae>> GetAllMaraeByHapuAsync(string hapuName, string sortby = "", string searchString = "", bool includeTangata = false)
        {
            return await maraeProvider.GetAllMaraeByHapuAsync(hapuName, sortby, searchString, includeTangata);
        }

        public async Task<Marae> GetMaraeByIdAsync(int id, bool includeTangata = false)
        {
            return await maraeProvider.GetMaraeByIdAsync(id, includeTangata);
        }

        public async Task<MaraeResponse> CreateMaraeAsync(Marae newMarae)
        {
            try
            {
                await maraeProvider.AddAsync(newMarae);
                await maraeUnitOfWork.CompleteAsync();

                return new MaraeResponse(newMarae);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MaraeResponse($"An error occurred when saving the Marae: {ex.Message}");
            }
        }

        public async Task<MaraeResponse> UpdateMaraeAsync(int id, Marae editMarae)
        {
            var existingMarae = await maraeProvider.GetMaraeByIdAsync(id);

            if (existingMarae == null)
                return new MaraeResponse("Marae not found.");

            existingMarae.Name = editMarae.Name;
            existingMarae.Area = editMarae.Area;
            existingMarae.Hapu = editMarae.Hapu;

            try
            {
                maraeProvider.Update(existingMarae);
                await maraeUnitOfWork.CompleteAsync();

                return new MaraeResponse(existingMarae);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new MaraeResponse($"An error occurred when updating the Marae: {ex.Message}");
            }
        }

        public async Task<MaraeResponse> DeleteMaraeAsync(int id)
        {
            var existingMarae = await maraeProvider.GetMaraeByIdAsync(id);

            if (existingMarae == null)
                return new MaraeResponse("Marae not found.");

            try
            {
                maraeProvider.Remove(existingMarae);
                await maraeUnitOfWork.CompleteAsync();

                return new MaraeResponse(existingMarae);
            }
            catch (Exception ex)
            {
                return new MaraeResponse($"An error occurred when saving the Tangata: {ex.Message}");
            }
        }
    }
}