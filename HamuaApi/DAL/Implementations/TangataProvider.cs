using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations

{
    public class TangataProvider : BaseProvider, ITangataProvider
    {
        public TangataProvider(HamuaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tangata>> GetAllTangataAsync(string sortby = "", string searchString = "", bool includeMarae = false, bool includeChildren = false)
        {
            var tangata = hamuaContext.NgaTangata.Select(x => x);

            if (includeMarae)
            {
                tangata = tangata.Include(x => x.NgaMarae);
            }

            if (includeChildren)
            {
                tangata = tangata.Include(x => x.Children);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                tangata = tangata.Where(x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));
            }

            switch (sortby)
            {
                case "firstname_desc":
                    tangata = tangata.OrderByDescending(s => s.FirstName);
                    break;

                case "firstname":
                    tangata = tangata.OrderBy(s => s.FirstName);
                    break;

                case "lastname_desc":
                    tangata = tangata.OrderByDescending(s => s.LastName);
                    break;

                default:
                    tangata = tangata.OrderBy(s => s.LastName);
                    break;
            }
            return await tangata.ToListAsync();
        }

        public async Task<Tangata> GetTangataByIdAsync(int id, bool includeMarae = false, bool includeChildren = false)
        {
            var tangata = hamuaContext.NgaTangata.Select(x => x);

            if (includeMarae)
            {
                tangata = tangata.Include(x => x.NgaMarae);
            }

            if (includeMarae)
            {
                tangata = tangata.Include(x => x.Children);
            }

            return await tangata.FirstOrDefaultAsync(x => x.TangataId.Equals(id));
        }

        public async Task AddAsync(Tangata tangata, IEnumerable<int> ngaMarae)
        {
            await hamuaContext.NgaTangata.AddAsync(tangata);

            foreach (var maraeId in ngaMarae)
            {
                var marae = await hamuaContext.NgaMarae.FindAsync(maraeId);
                tangata.NgaMarae.Add(marae);
            }
        }
    }
}