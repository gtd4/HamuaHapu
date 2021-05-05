using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HamuaHapuRegistration.Models;

namespace HamuaHapuRegistration.Data
{
    public class HamuaHapuRegistrationContext : DbContext
    {
        public HamuaHapuRegistrationContext (DbContextOptions<HamuaHapuRegistrationContext> options)
            : base(options)
        {
        }

        public DbSet<HamuaHapuRegistration.Models.HapuMember> HapuMember { get; set; }
    }
}
