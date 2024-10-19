﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelTo.Data;

#nullable disable

namespace TravelTo.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    partial class ApplicationDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TravelTo.Models.Company", b =>
                {
                    b.Property<int>("Company_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Company_Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("owner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Company_Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Company_Id = 1,
                            Name = "TBCKVADRO",
                            description = "saswauli kompania romelic arasdros iarsebs",
                            img_name = "tbc_image.png",
                            owner = "gela"
                        },
                        new
                        {
                            Company_Id = 2,
                            Name = "liberti",
                            description = "raxdeba sh",
                            img_name = "liberti_img.png",
                            owner = "NEKA"
                        },
                        new
                        {
                            Company_Id = 3,
                            Name = "bog",
                            description = "imedia",
                            img_name = "bog_image.png",
                            owner = "NAK"
                        },
                        new
                        {
                            Company_Id = 4,
                            Name = "kripto",
                            description = "iarsebs",
                            img_name = "credit_bank.png",
                            owner = "bark"
                        });
                });

            modelBuilder.Entity("TravelTo.Models.ContactPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Messege")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Telephoni")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactiUndat");
                });

            modelBuilder.Entity("TravelTo.Models.Sastumroebi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fasi")
                        .HasColumnType("int");

                    b.Property<string>("Lokacia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sastumroebis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "es sastumro mdebareobs dedamiwis mwervalze romelzedac iyo guini",
                            Fasi = 100,
                            Lokacia = "Dedamiwis Centri",
                            Name = "Robotiqsi",
                            gmail = "gmail@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Es sastumro mdebareobs msoflios yvelaze civ wertislhi wesit esaaa",
                            Fasi = 50,
                            Lokacia = "AntarqtidaOnTop",
                            Name = "Antarqtida",
                            gmail = "antarqtida@gmail.com"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Tbilisi tbilisi tbilisi uni uni uni btu ilia japan tsu .",
                            Fasi = 75,
                            Lokacia = "Tbilisi City Center",
                            Name = "Tbilisi",
                            gmail = "tbilisi@gmail.com"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Kutaisi kutaisi kutaisi ratqmaunda kutasisi rogorc yoveltvbis kutaisi.",
                            Fasi = 60,
                            Lokacia = "Kutaisi Historical Area",
                            Name = "Kutaisi",
                            gmail = "kutaisi@gmail.com"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Batumi bautmi bautmi zfgva zgva zgva meti meti meti .",
                            Fasi = 80,
                            Lokacia = "Batumi Boulevard",
                            Name = "Batumi",
                            gmail = "batumi@gmail.com"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Mtskheta es xom mcxetaa mcxetaa azrze ar var ra davwero amaze.",
                            Fasi = 40,
                            Lokacia = "Mtskheta Old Town",
                            Name = "Mtskheta",
                            gmail = "mtskheta@gmail.com"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Zugdidi es xom zugdidia yvelaze didi farti romelic daixarja",
                            Fasi = 30,
                            Lokacia = "Zugdidi Park",
                            Name = "Zugdidi",
                            gmail = "zugdidi@gmail.com"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Gori gori gori amis meti ra unda vtqva es xom goria gorta shoris.",
                            Fasi = 45,
                            Lokacia = "Gori Fortress",
                            Name = "Gori",
                            gmail = "gori@gmail.com"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Telavi telavi telavi azrze ar var ra davwero amashi mara telaviaMountains.",
                            Fasi = 55,
                            Lokacia = "Telavi Wine Region",
                            Name = "Telavi",
                            gmail = "telavi@gmail.com"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Signagi signagi signagi es xom signagia azrze ar var ra  davwero amazec amitomac signagi signagia.",
                            Fasi = 65,
                            Lokacia = "Signagi Hilltop",
                            Name = "Signagi",
                            gmail = "signagi@gmail.com"
                        });
                });

            modelBuilder.Entity("TravelTo.Models.Turebi", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Company_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("image_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Company_Id");

                    b.ToTable("Turebis");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Company_Id = 1,
                            Description = "aq iyo batoni wyali romelmac wyali dalia",
                            Name = "Antarqtida",
                            Price = 5.9900000000000002,
                            image_name = "antarqtida.jpg"
                        },
                        new
                        {
                            id = 2,
                            Company_Id = 3,
                            Description = "tbilo tibifli",
                            Name = "Tbilisi",
                            Price = 15.99,
                            image_name = "Tbilisi.jpg"
                        },
                        new
                        {
                            id = 3,
                            Company_Id = 2,
                            Description = "parizelta dedaqali",
                            Name = "Parizi",
                            Price = 6.9900000000000002,
                            image_name = "Parizi.jfif"
                        },
                        new
                        {
                            id = 4,
                            Company_Id = 4,
                            Description = "მაგარიი პონტიიი",
                            Name = "Los-Angeles, CA",
                            Price = 15555.0,
                            image_name = "Los-AngelesCa.jfif"
                        },
                        new
                        {
                            id = 5,
                            Company_Id = 1,
                            Description = "მაგარიი პონტიიი",
                            Name = "Italy",
                            Price = 12341.0,
                            image_name = "Italy.png"
                        },
                        new
                        {
                            id = 6,
                            Company_Id = 2,
                            Description = "მაგარიი პონტიიი",
                            Name = "Brazil",
                            Price = 15111.0,
                            image_name = "Brazil.jfif"
                        },
                        new
                        {
                            id = 7,
                            Company_Id = 4,
                            Description = "მაგარიი პონტიიი",
                            Name = "Denmark",
                            Price = 19000.0,
                            image_name = "Denmark.jfif"
                        },
                        new
                        {
                            id = 8,
                            Company_Id = 3,
                            Description = "მაგარიი პონტიიი",
                            Name = "Spain",
                            Price = 23000.0,
                            image_name = "Spain.jfif"
                        });
                });

            modelBuilder.Entity("TravelTo.Models.TvisebebiSastumroebis", b =>
                {
                    b.Property<int>("Tviseba_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Tviseba_Id"));

                    b.Property<int>("Sastumros_Id")
                        .HasColumnType("int");

                    b.Property<string>("Shinauri_cxovelebis_dashveba")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ufaso_avtosadgomi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wifi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bagi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bari")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("daxuruli_auzi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kino_darbasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("otaxi_aramweveltaTvis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resotrani")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sabavsho_otaxi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sabiliardo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sakonferencio_darbazi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("samrecxao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sauna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spa_centri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sportdarbazi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("terasa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Tviseba_Id");

                    b.HasIndex("Sastumros_Id");

                    b.ToTable("TvisebebiDaSastumroebi");
                });

            modelBuilder.Entity("TravelTo.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TravelTo.Models.UserAndTurebiMap", b =>
                {
                    b.Property<int?>("Turebi_Id")
                        .HasColumnType("int");

                    b.Property<string>("User_Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Turebi_Id", "User_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("UserAndTurebi");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TravelTo.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TravelTo.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelTo.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TravelTo.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelTo.Models.Turebi", b =>
                {
                    b.HasOne("TravelTo.Models.Company", "Company")
                        .WithMany("Turebi")
                        .HasForeignKey("Company_Id");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("TravelTo.Models.TvisebebiSastumroebis", b =>
                {
                    b.HasOne("TravelTo.Models.Sastumroebi", "Sastumro")
                        .WithMany("Tvisebebis_Sastumroebi")
                        .HasForeignKey("Sastumros_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sastumro");
                });

            modelBuilder.Entity("TravelTo.Models.UserAndTurebiMap", b =>
                {
                    b.HasOne("TravelTo.Models.Turebi", "turebi")
                        .WithMany("UserAndTurebiMapT")
                        .HasForeignKey("Turebi_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelTo.Models.User", "User")
                        .WithMany("UserAndTurebiMapU")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("turebi");
                });

            modelBuilder.Entity("TravelTo.Models.Company", b =>
                {
                    b.Navigation("Turebi");
                });

            modelBuilder.Entity("TravelTo.Models.Sastumroebi", b =>
                {
                    b.Navigation("Tvisebebis_Sastumroebi");
                });

            modelBuilder.Entity("TravelTo.Models.Turebi", b =>
                {
                    b.Navigation("UserAndTurebiMapT");
                });

            modelBuilder.Entity("TravelTo.Models.User", b =>
                {
                    b.Navigation("UserAndTurebiMapU");
                });
#pragma warning restore 612, 618
        }
    }
}
