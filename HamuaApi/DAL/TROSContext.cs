using HamuaRegistrationApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL
{
    public class HamuaContext : DbContext
    {
        public HamuaContext(DbContextOptions<HamuaContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marae>()
            .HasKey(o => new { o.MaraeId });

            //Add contraint to stop double up orders being created

            //modelBuilder.Entity<TROSClassShipToAddress>()
            //    .HasKey(x => new { x.Id });
        }

        public DbSet<Marae> NgaMarae { get; set; }

        //public DbSet<TROSClassShipToAddress> ShipToAddresses { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        OnHold,
        Sent,
        Deleted,
        Processing
    }
}