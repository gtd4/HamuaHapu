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

        public async Task<IEnumerable<Marae>> GetAllMaraeAsync(string sortby = "", string searchString = "", bool include = false)
        {
            var marae = maraeContext.NgaMarae.Select(x => x);

            if (include)
            {
                marae = marae.Include(x => x.NgaTangata);
            }

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

                case "area":
                    marae = marae.OrderBy(s => s.Area);
                    break;

                case "area_desc":
                    marae = marae.OrderByDescending(s => s.Area);
                    break;

                default:
                    marae = marae.OrderBy(s => s.Name);
                    break;
            }
            return await marae.ToListAsync();
        }

        public async Task<IEnumerable<Marae>> GetAllMaraeByAreaAsync(string areaName, string sortby, string searchString = "", bool include = false)
        {
            var marae = await GetAllMaraeAsync(sortby, searchString, include);

            return marae.Where(x => x.Area.Equals(areaName)); ;
        }

        public async Task<IEnumerable<Marae>> GetAllMaraeByHapuAsync(string hapuName, string sortby, string searchString = "", bool include = false)
        {
            var marae = await GetAllMaraeAsync(sortby, searchString, include);

            return marae.Where(x => x.Hapu.Equals(hapuName)); ;
        }

        public async Task<Marae> GetMaraeByIdAsync(int id, bool include = false)
        {
            var marae = await GetAllMaraeAsync("", "", include);

            return marae.Where(x => x.MaraeId == id).FirstOrDefault();
        }
    }
}