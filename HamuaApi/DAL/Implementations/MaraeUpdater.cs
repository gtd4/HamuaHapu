using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations

{
    public class MaraeUpdater : IMaraeUpdater
    {
        private HamuaContext maraeContext;
        private IMaraeProvider maraeProvider;

        public MaraeUpdater(HamuaContext context, IMaraeProvider provider)
        {
            maraeContext = context;
            maraeProvider = provider;
        }

        public async Task<Marae> CreateMaraeAsync(Marae newMarae)
        {
            try
            {
                await maraeContext.NgaMarae.AddAsync(newMarae);
                await maraeContext.SaveChangesAsync();

                return newMarae;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Marae> DeleteMaraeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Marae> UpdateMaraeAsync(int id, string area, string maraeName, string hapu)
        {
            try
            {
                var marae = await maraeProvider.GetMaraeByIdAsync(id);

                if (!string.IsNullOrEmpty(area))
                {
                    marae.Area = area;
                }

                if (!string.IsNullOrEmpty(maraeName))
                {
                    marae.Area = maraeName;
                }

                if (!string.IsNullOrEmpty(hapu))
                {
                    marae.Area = hapu;
                }

                maraeContext.Update(marae);
                maraeContext.SaveChanges();

                return marae;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}