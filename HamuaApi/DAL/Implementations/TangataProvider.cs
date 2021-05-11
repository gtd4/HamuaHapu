﻿using HamuaRegistrationApi.DAL.Interfaces;
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

        public async Task<IEnumerable<Tangata>> GetAllTangataAsync(string sortby = "", string searchString = "", bool include = false)
        {
            var tangata = hamuaContext.NgaTangata.Select(x => x);

            if (include)
            {
                tangata = tangata.Include(x => x.NgaMarae);
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

        public async Task<Tangata> GetTangataByIdAsync(int id, bool include = false)
        {
            if (include)
            {
                return await hamuaContext.NgaTangata.Include(x => x.NgaMarae).FirstOrDefaultAsync(x => x.TangataId == id);
            }

            return await hamuaContext.NgaTangata.FindAsync(id);
        }

        public async Task AddAsync(Tangata tangata, IEnumerable<Marae> ngaMarae)
        {
            await hamuaContext.AddAsync(tangata);

            foreach (var marae in ngaMarae)
            {
                var savedMarae = await hamuaContext.NgaMarae.FindAsync(marae.MaraeId);
                savedMarae.NgaTangata.Add(tangata);
            }
        }
    }
}