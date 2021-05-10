﻿using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations

{
    public class TangataProvider : ITangataProvider
    {
        private HamuaContext tangataContext;

        public TangataProvider(HamuaContext context)
        {
            tangataContext = context;
        }

        public async Task<IEnumerable<Tangata>> GetAllTangataAsync(string sortby = "", string searchString = "")
        {
            var tangata = tangataContext.NgaTangata.Select(x => x);

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

        public async Task<Tangata> GetTangataByIdAsync(int id)
        {
            return await tangataContext.NgaTangata.FindAsync(id);
        }
    }
}