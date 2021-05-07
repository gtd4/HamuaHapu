using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations

{
    public class TangataUpdater : ITangataUpdater
    {
        private HamuaContext tangataContext;
        private ITangataProvider tangataProvider;

        public TangataUpdater(HamuaContext context, ITangataProvider provider)
        {
            tangataContext = context;
            tangataProvider = provider;
        }

        public async Task<Tangata> CreateTangataAsync(Tangata newTangata)
        {
            try
            {
                var tangata = new Tangata { FirstName = newTangata.FirstName, LastName = newTangata.LastName };

                foreach (var marae in newTangata.NgaMarae)
                {
                    var savedMarae = await tangataContext.NgaMarae.FindAsync(marae.MaraeId);
                    tangata.NgaMarae.Add(marae);
                }

                //await tangataContext.NgaTangata.AddAsync(tangata);
                var id = await tangataContext.SaveChangesAsync();

                return await tangataContext.NgaTangata.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tangata> UpdateTangataAsync(int id, string firstName, string lastName)
        {
            try
            {
                var tangata = await tangataProvider.GetTangataByIdAsync(id);

                if (!string.IsNullOrEmpty(firstName))
                {
                    tangata.FirstName = firstName;
                }

                if (!string.IsNullOrEmpty(lastName))
                {
                    tangata.LastName = lastName;
                }

                tangataContext.Update(tangata);
                tangataContext.SaveChanges();

                return tangata;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}