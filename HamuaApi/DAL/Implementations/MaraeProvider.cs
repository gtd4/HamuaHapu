using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations

{
    public class MaraeProvider : IMaraeProvider
    {
        private HamuaContext maraeContext;

        public MaraeProvider(HamuaContext context)
        {
            maraeContext = context;
        }

        public async Task<IEnumerable<Marae>> GetAllMaraeAsync(string sortby, string searchString = "")
        {
            var marae = maraeContext.NgaMarae.Select(x => x);

            if (!string.IsNullOrEmpty(searchString))
            {
                marae = marae.Where(x => x.Area.Contains(searchString) || x.Hapu.Contains(searchString) || x.Name.Contains(searchString));
            }

            switch (sortby)
            {
                case "marae_desc":
                    marae = marae.OrderByDescending(s => s.Name);
                    break;

                case "hapu":
                    marae = marae.OrderBy(s => s.Hapu);
                    break;

                case "hapu_desc":
                    marae = marae.OrderByDescending(s => s.Hapu);
                    break;

                default:
                    marae = marae.OrderBy(s => s.Name);
                    break;
            }
            return await marae.ToListAsync();
        }

        public async Task<IEnumerable<Marae>> GetAllOrdersByAreaAsync(string areaName, string sortby, string searchString = "")
        {
            var marae = await GetAllMaraeAsync(sortby, searchString);

            return marae.Where(x => x.Area.Equals(areaName)); ;
        }

        public async Task<IEnumerable<Marae>> GetAllOrdersByHapuAsync(string hapuName, string sortby, string searchString = "")
        {
            var marae = await GetAllMaraeAsync(sortby, searchString);

            return marae.Where(x => x.Hapu.Equals(hapuName)); ;
        }

        public async Task<Marae> GetMaraeByIdAsync(int id)
        {
            return await maraeContext.NgaMarae.FindAsync(id);
        }
    }
}