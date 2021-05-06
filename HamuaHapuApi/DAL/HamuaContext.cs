using HamuaHapuApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuApi.DAL
{
    public class HamuaContext : DbContext
    {
        public DbSet<NgaMarae> NgaMarae { get; set; }

        public HamuaContext(DbContextOptions<HamuaContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("HamuaContext");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NgaMarae>()
            .HasKey(o => new
            {
                o.ID
            });
        }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
    }
}