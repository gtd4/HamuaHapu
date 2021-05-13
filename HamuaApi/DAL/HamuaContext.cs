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
            //modelBuilder.Entity<Marae>()
            //.HasKey(o => new { o.MaraeId });

            modelBuilder.Entity<Tangata>()
                .HasOne(mother => mother.Mother)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.MotherID);

            modelBuilder.Entity<Tangata>()
                .Ignore(x => x.Children)
                .HasOne(father => father.Father)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.FatherID);

            //modelBuilder.Entity<Tangata>()
            //    .HasMany(x => x.Children);

            modelBuilder.Entity<Marae>().HasData(
                new Marae { MaraeId = 1, Area = "Rūātoki", Name = "Ngāhina", Hapu = "Ngāti Tāwhaki" },
                new Marae { MaraeId = 2, Area = "Rūātoki", Name = "Ōhotu", Hapu = "Te Whānau Pani" },
                new Marae { MaraeId = 3, Area = "Rūātoki", Name = "Ōtenuku", Hapu = "Ngāti Kōura" },
                new Marae { MaraeId = 4, Area = "Rūātoki", Name = "Ōwhakatoro", Hapu = "Ngāti Rongo" },
                new Marae { MaraeId = 5, Area = "Rūātoki", Name = "Paneteure", Hapu = "Ngāti Rongo" },
                new Marae { MaraeId = 6, Area = "Rūātoki", Name = "Papakāinga", Hapu = "Ngāti Kōura" },
                new Marae { MaraeId = 7, Area = "Rūātoki", Name = "Te Rewarewa", Hapu = "Te Māhurehure" },
                new Marae { MaraeId = 8, Area = "Rūātoki", Name = "Tauarau", Hapu = "Ngāti Rongo" },
                new Marae { MaraeId = 9, Area = "Rūātoki", Name = "Te Poho o Te Rangimōnoa", Hapu = "Ngāti Mura" },
                new Marae { MaraeId = 10, Area = "Rūātoki", Name = "Te Tōtara", Hapu = "Te Urewera" },
                new Marae { MaraeId = 11, Area = "Ruatāhuna", Name = "Mātatua", Hapu = "Te Urewera" },
                new Marae { MaraeId = 12, Area = "Ruatāhuna", Name = "Ōhāua", Hapu = "Ngāti Rongo" },
                new Marae { MaraeId = 13, Area = "Ruatāhuna", Name = "Ōpūtao", Hapu = "Ngāti Tāwhaki" },
                new Marae { MaraeId = 14, Area = "Ruatāhuna", Name = "Ōtekura", Hapu = "Tamakaimoana" },
                new Marae { MaraeId = 15, Area = "Ruatāhuna", Name = "Pāpueru", Hapu = "Ngāti Tāwhaki" },
                new Marae { MaraeId = 16, Area = "Ruatāhuna", Name = "Tātāhoata", Hapu = "Ngāi Te Riu" },
                new Marae { MaraeId = 17, Area = "Ruatāhuna", Name = "Te Umuroa", Hapu = "Ngāti Manunui" },
                new Marae { MaraeId = 18, Area = "Ruatāhuna", Name = "Te Wai-iti", Hapu = "Ngāti Kurīkino" },
                new Marae { MaraeId = 19, Area = "Ruatāhuna", Name = "Tīpapa", Hapu = "Kākahu Tāpiki" },
                new Marae { MaraeId = 20, Area = "Ruatāhuna", Name = "Uwhiārae", Hapu = "Ngāi Te Paena" },
                new Marae { MaraeId = 21, Area = "Te Whāiti", Name = "Waikotikoti", Hapu = "Te Karaha Warahoe" },
                new Marae { MaraeId = 22, Area = "Waikaremoana", Name = "Te Kūhā Tārewa", Hapu = "Ngāti Ruapani ki Waikaremoana Ngāti Hinekura" },
                new Marae { MaraeId = 23, Area = "Waikaremoana", Name = "Waimako", Hapu = "Te Whānau Pani" },
                new Marae { MaraeId = 24, Area = "Waiōhau", Name = "Waiōhau", Hapu = "Ngāti Haka Patuheuheu" },
                new Marae { MaraeId = 25, Area = "Waimana", Name = "Kahikatea", Hapu = "Ngāti Kōura" },
                new Marae { MaraeId = 26, Area = "Waimana", Name = "Kutarere", Hapu = "Tūranga Pikitoi" },
                new Marae { MaraeId = 27, Area = "Waimana", Name = "Maromahue", Hapu = "Ngāi Tamatea" },
                new Marae { MaraeId = 28, Area = "Waimana", Name = "Matahī", Hapu = "Ngāi Tamatuhirae" },
                new Marae { MaraeId = 29, Area = "Waimana", Name = "Piripari", Hapu = "Ngāi Tātua Tamakaimoana" },
                new Marae { MaraeId = 30, Area = "Waimana", Name = "Rāhiri", Hapu = "Ngāti Rere" },
                new Marae { MaraeId = 31, Area = "Waimana", Name = "Rāroa", Hapu = "Tamaruarangi" },
                new Marae { MaraeId = 32, Area = "Waimana", Name = "Tanatana", Hapu = "Ngāti Rere" },
                new Marae { MaraeId = 33, Area = "Waimana", Name = "Tātaiāhape", Hapu = "Ngāti Raka" },
                new Marae { MaraeId = 34, Area = "Waimana", Name = "Tauanui", Hapu = "Te Whakatāne" },
                new Marae { MaraeId = 35, Area = "Waimana", Name = "Te Pou a Hīnau", Hapu = "Tūranga Pikitoi" },
                new Marae { MaraeId = 36, Area = "Waimana", Name = "Tuapō", Hapu = "Tamakaimoana" },
                new Marae { MaraeId = 37, Area = "Waimana", Name = "Whakara", Hapu = "Te Whakatāne" },
                new Marae { MaraeId = 38, Area = "Maungapōhatu", Name = "ManungapōhatuT", Hapu = "Tamakaimoana Ngāti Huri" }

                );

            //Add contraint to stop double up orders being created

            //modelBuilder.Entity<TROSClassShipToAddress>()
            //    .HasKey(x => new { x.Id });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Marae> NgaMarae { get; set; }
        public DbSet<Tangata> NgaTangata { get; set; }

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