﻿// <auto-generated />
using System;
using HamuaRegistrationApi.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HamuaRegistrationApi.Migrations
{
    [DbContext(typeof(HamuaContext))]
    [Migration("20210518111619_azureDB")]
    partial class azureDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HamuaRegistrationApi.DAL.Models.Marae", b =>
                {
                    b.Property<int>("MaraeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hapu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaraeId");

                    b.ToTable("NgaMarae");

                    b.HasData(
                        new
                        {
                            MaraeId = 1,
                            Area = "Rūātoki",
                            Hapu = "Ngāti Tāwhaki",
                            Name = "Ngāhina"
                        },
                        new
                        {
                            MaraeId = 2,
                            Area = "Rūātoki",
                            Hapu = "Te Whānau Pani",
                            Name = "Ōhotu"
                        },
                        new
                        {
                            MaraeId = 3,
                            Area = "Rūātoki",
                            Hapu = "Ngāti Kōura",
                            Name = "Ōtenuku"
                        },
                        new
                        {
                            MaraeId = 4,
                            Area = "Rūātoki",
                            Hapu = "Ngāti Rongo",
                            Name = "Ōwhakatoro"
                        },
                        new
                        {
                            MaraeId = 5,
                            Area = "Rūātoki",
                            Hapu = "Ngāti Rongo",
                            Name = "Paneteure"
                        },
                        new
                        {
                            MaraeId = 6,
                            Area = "Rūātoki",
                            Hapu = "Ngāti Kōura",
                            Name = "Papakāinga"
                        },
                        new
                        {
                            MaraeId = 7,
                            Area = "Rūātoki",
                            Hapu = "Te Māhurehure",
                            Name = "Te Rewarewa"
                        },
                        new
                        {
                            MaraeId = 8,
                            Area = "Rūātoki",
                            Hapu = "Ngāti Rongo",
                            Name = "Tauarau"
                        },
                        new
                        {
                            MaraeId = 9,
                            Area = "Rūātoki",
                            Hapu = "Ngāti Mura",
                            Name = "Te Poho o Te Rangimōnoa"
                        },
                        new
                        {
                            MaraeId = 10,
                            Area = "Rūātoki",
                            Hapu = "Te Urewera",
                            Name = "Te Tōtara"
                        },
                        new
                        {
                            MaraeId = 11,
                            Area = "Ruatāhuna",
                            Hapu = "Te Urewera",
                            Name = "Mātatua"
                        },
                        new
                        {
                            MaraeId = 12,
                            Area = "Ruatāhuna",
                            Hapu = "Ngāti Rongo",
                            Name = "Ōhāua"
                        },
                        new
                        {
                            MaraeId = 13,
                            Area = "Ruatāhuna",
                            Hapu = "Ngāti Tāwhaki",
                            Name = "Ōpūtao"
                        },
                        new
                        {
                            MaraeId = 14,
                            Area = "Ruatāhuna",
                            Hapu = "Tamakaimoana",
                            Name = "Ōtekura"
                        },
                        new
                        {
                            MaraeId = 15,
                            Area = "Ruatāhuna",
                            Hapu = "Ngāti Tāwhaki",
                            Name = "Pāpueru"
                        },
                        new
                        {
                            MaraeId = 16,
                            Area = "Ruatāhuna",
                            Hapu = "Ngāi Te Riu",
                            Name = "Tātāhoata"
                        },
                        new
                        {
                            MaraeId = 17,
                            Area = "Ruatāhuna",
                            Hapu = "Ngāti Manunui",
                            Name = "Te Umuroa"
                        },
                        new
                        {
                            MaraeId = 18,
                            Area = "Ruatāhuna",
                            Hapu = "Ngāti Kurīkino",
                            Name = "Te Wai-iti"
                        },
                        new
                        {
                            MaraeId = 19,
                            Area = "Ruatāhuna",
                            Hapu = "Kākahu Tāpiki",
                            Name = "Tīpapa"
                        },
                        new
                        {
                            MaraeId = 20,
                            Area = "Ruatāhuna",
                            Hapu = "Ngāi Te Paena",
                            Name = "Uwhiārae"
                        },
                        new
                        {
                            MaraeId = 21,
                            Area = "Te Whāiti",
                            Hapu = "Te Karaha Warahoe",
                            Name = "Waikotikoti"
                        },
                        new
                        {
                            MaraeId = 22,
                            Area = "Waikaremoana",
                            Hapu = "Ngāti Ruapani ki Waikaremoana Ngāti Hinekura",
                            Name = "Te Kūhā Tārewa"
                        },
                        new
                        {
                            MaraeId = 23,
                            Area = "Waikaremoana",
                            Hapu = "Te Whānau Pani",
                            Name = "Waimako"
                        },
                        new
                        {
                            MaraeId = 24,
                            Area = "Waiōhau",
                            Hapu = "Ngāti Haka Patuheuheu",
                            Name = "Waiōhau"
                        },
                        new
                        {
                            MaraeId = 25,
                            Area = "Waimana",
                            Hapu = "Ngāti Kōura",
                            Name = "Kahikatea"
                        },
                        new
                        {
                            MaraeId = 26,
                            Area = "Waimana",
                            Hapu = "Tūranga Pikitoi",
                            Name = "Kutarere"
                        },
                        new
                        {
                            MaraeId = 27,
                            Area = "Waimana",
                            Hapu = "Ngāi Tamatea",
                            Name = "Maromahue"
                        },
                        new
                        {
                            MaraeId = 28,
                            Area = "Waimana",
                            Hapu = "Ngāi Tamatuhirae",
                            Name = "Matahī"
                        },
                        new
                        {
                            MaraeId = 29,
                            Area = "Waimana",
                            Hapu = "Ngāi Tātua Tamakaimoana",
                            Name = "Piripari"
                        },
                        new
                        {
                            MaraeId = 30,
                            Area = "Waimana",
                            Hapu = "Ngāti Rere",
                            Name = "Rāhiri"
                        },
                        new
                        {
                            MaraeId = 31,
                            Area = "Waimana",
                            Hapu = "Tamaruarangi",
                            Name = "Rāroa"
                        },
                        new
                        {
                            MaraeId = 32,
                            Area = "Waimana",
                            Hapu = "Ngāti Rere",
                            Name = "Tanatana"
                        },
                        new
                        {
                            MaraeId = 33,
                            Area = "Waimana",
                            Hapu = "Ngāti Raka",
                            Name = "Tātaiāhape"
                        },
                        new
                        {
                            MaraeId = 34,
                            Area = "Waimana",
                            Hapu = "Te Whakatāne",
                            Name = "Tauanui"
                        },
                        new
                        {
                            MaraeId = 35,
                            Area = "Waimana",
                            Hapu = "Tūranga Pikitoi",
                            Name = "Te Pou a Hīnau"
                        },
                        new
                        {
                            MaraeId = 36,
                            Area = "Waimana",
                            Hapu = "Tamakaimoana",
                            Name = "Tuapō"
                        },
                        new
                        {
                            MaraeId = 37,
                            Area = "Waimana",
                            Hapu = "Te Whakatāne",
                            Name = "Whakara"
                        },
                        new
                        {
                            MaraeId = 38,
                            Area = "Maungapōhatu",
                            Hapu = "Tamakaimoana Ngāti Huri",
                            Name = "ManungapōhatuT"
                        });
                });

            modelBuilder.Entity("HamuaRegistrationApi.DAL.Models.Tangata", b =>
                {
                    b.Property<int>("TangataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CanYouSpeakTeReo")
                        .HasColumnType("bit");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FatherID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTeReoFirstLanguage")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MotherID")
                        .HasColumnType("int");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReturnComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ReturnToRuatokiToLive")
                        .HasColumnType("bit");

                    b.Property<string>("SpecialtySkills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeReoProficiency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TangataId");

                    b.HasIndex("FatherID");

                    b.HasIndex("MotherID");

                    b.ToTable("NgaTangata");
                });

            modelBuilder.Entity("MaraeTangata", b =>
                {
                    b.Property<int>("NgaMaraeMaraeId")
                        .HasColumnType("int");

                    b.Property<int>("NgaTangataTangataId")
                        .HasColumnType("int");

                    b.HasKey("NgaMaraeMaraeId", "NgaTangataTangataId");

                    b.HasIndex("NgaTangataTangataId");

                    b.ToTable("MaraeTangata");
                });

            modelBuilder.Entity("HamuaRegistrationApi.DAL.Models.Tangata", b =>
                {
                    b.HasOne("HamuaRegistrationApi.DAL.Models.Tangata", "Father")
                        .WithMany("Children")
                        .HasForeignKey("FatherID");

                    b.HasOne("HamuaRegistrationApi.DAL.Models.Tangata", "Mother")
                        .WithMany()
                        .HasForeignKey("MotherID");

                    b.Navigation("Father");

                    b.Navigation("Mother");
                });

            modelBuilder.Entity("MaraeTangata", b =>
                {
                    b.HasOne("HamuaRegistrationApi.DAL.Models.Marae", null)
                        .WithMany()
                        .HasForeignKey("NgaMaraeMaraeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamuaRegistrationApi.DAL.Models.Tangata", null)
                        .WithMany()
                        .HasForeignKey("NgaTangataTangataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HamuaRegistrationApi.DAL.Models.Tangata", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
