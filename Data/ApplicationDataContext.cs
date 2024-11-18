using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelTo.Models;

namespace TravelTo.Data
{
    public class ApplicationDataContext:IdentityDbContext<User>
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Turebi> Turebis { get; set; }
        public DbSet<UserAndTurebiMap> UserAndTurebi{ get; set; }
        public DbSet<ContactPerson> ContactiUndat { get; set; }
        public DbSet<Sastumroebi> Sastumroebis { get; set; }
        public DbSet<TvisebebiSastumroebis> TvisebebiDaSastumroebi { get; set; }
        public DbSet<UserAndSastumroebi> userAndSastumroebis{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Company>().HasData(
                new Company { Company_Id = 1, owner = "gela", description = "saswauli kompania romelic arasdros iarsebs", Name = "TBCKVADRO", img_name = "tbc_image.png" },
                new Company { Company_Id = 2, owner = "NEKA", description = "raxdeba sh", Name = "liberti", img_name = "liberti_img.png" },
                new Company { Company_Id = 3, owner = "NAK", description = "imedia", Name = "bog", img_name = "bog_image.png" },
                new Company { Company_Id = 4, owner = "bark", description = "iarsebs", Name = "kripto", img_name = "credit_bank.png" }
                );
            modelBuilder.Entity<Turebi>().HasData(
                new Turebi { id = 1, Name = "Antarqtida", Description = "aq iyo batoni wyali romelmac wyali dalia", Price = 5.99, image_name = "antarqtida.jpg", Company_Id = 1 },
                new Turebi { id = 2, Name = "Tbilisi", Description = "tbilo tibifli", Price = 15.99, image_name = "Tbilisi.jpg", Company_Id = 3 },
                new Turebi { id = 3, Name = "Parizi", Description = "parizelta dedaqali", Price = 6.99, image_name = "Parizi.jfif", Company_Id = 2 },
                new Turebi { id = 4, Name = "Los-Angeles, CA", Description = "მაგარიი პონტიიი", Price = 15555, image_name = "Los-AngelesCa.jfif", Company_Id = 4 },
                new Turebi { id = 5, Name = "Italy", Description = "მაგარიი პონტიიი", Price = 12341, image_name = "Italy.png", Company_Id = 1 },
                new Turebi { id = 6, Name = "Brazil", Description = "მაგარიი პონტიიი", Price = 15111, image_name = "Brazil.jfif", Company_Id = 2 },
                new Turebi { id = 7, Name = "Denmark", Description = "მაგარიი პონტიიი", Price = 19000, image_name = "Denmark.jfif", Company_Id = 4 },
                new Turebi { id = 8, Name = "Spain", Description = "მაგარიი პონტიიი", Price = 23000, image_name = "Spain.jfif", Company_Id = 3 }
                );
			modelBuilder.Entity<Sastumroebi>().HasData(
          new Sastumroebi {Id = 1, Lokacia = "Robotiqsi", Fasi = 100, Description = "es sastumro mdebareobs dedamiwis mwervalze romelzedac iyo guini", gmail = "gmail@gmail.com", Name = "Robotiqsi Grand Hotel", image_name = "1.jpeg" , Tviseba_Id = 1 },
          new Sastumroebi { Id = 2, Lokacia = "Antarqtida", Fasi = 50, Description = "Es sastumro mdebareobs msoflios yvelaze civ wertislhi wesit esaaa", gmail = "antarqtida@gmail.com", Name = "Antarqtida Luxury Suites", image_name = "2.jpg" , Tviseba_Id = 2 },
          new Sastumroebi { Id = 3, Lokacia = "Tbilisi", Fasi = 75, Description = "Tbilisi tbilisi tbilisi uni uni uni btu ilia japan tsu.", gmail = "tbilisi@gmail.com", Name = "Tbilisi City Hotel", image_name = "3.jpg" , Tviseba_Id = 3 },
          new Sastumroebi { Id = 4, Lokacia = "Kutaisi", Fasi = 60, Description = "Kutaisi kutaisi kutaisi ratqmaunda kutasisi rogorc yoveltvbis kutaisi.", gmail = "kutaisi@gmail.com", Name = "Kutaisi Boutique Hotel", image_name = "4.webp",Tviseba_Id=4 },
          new Sastumroebi { Id = 5, Lokacia = "Batumi", Fasi = 80, Description = "Batumi bautmi bautmi zfgva zgva zgva meti meti meti.", gmail = "batumi@gmail.com", Name = "Batumi Beach Resort", image_name = "5.jpg" , Tviseba_Id = 5 },
          new Sastumroebi { Id = 6, Lokacia = "Mtskheta", Fasi = 40, Description = "Mtskheta es xom mcxetaa mcxetaa azrze ar var ra davwero amaze.", gmail = "mtskheta@gmail.com", Name = "Mtskheta Heritage Inn", image_name = "6.jpg" ,    Tviseba_Id = 6 },
          new Sastumroebi { Id = 7, Lokacia = "Zugdidi", Fasi = 30, Description = "Zugdidi es xom zugdidia yvelaze didi farti romelic daixarja", gmail = "zugdidi@gmail.com", Name = "Zugdidi Park Hotel", image_name = "7.jpg" , Tviseba_Id = 7 },
          new Sastumroebi { Id = 8, Lokacia = "Gori", Fasi = 45, Description = "Gori gori gori amis meti ra unda vtqva es xom goria gorta shoris.", gmail = "gori@gmail.com", Name = "Gori Fortress Hotel", image_name = "8.jpg" ,Tviseba_Id=8},
          new Sastumroebi { Id = 9, Lokacia = "Telavi", Fasi = 55, Description = "Telavi telavi telavi azrze ar var ra davwero amashi mara telaviaMountains.", gmail = "telavi@gmail.com", Name = "Telavi Wine Hotel", image_name = "9.jpg",Tviseba_Id=9 },
          new Sastumroebi { Id = 10, Lokacia = "Signagi", Fasi = 65, Description = "Signagi signagi signagi es xom signagia azrze ar var ra davwero amazec amitomac signagi signagia.", gmail = "signagi@gmail.com", Name = "Signagi Hilltop Hotel", image_name = "10.jpg" , Tviseba_Id = 10 }
	  );
            modelBuilder.Entity<TvisebebiSastumroebis>().HasData(
                new TvisebebiSastumroebis
                {
                    Tviseba_Id = 1,
                    Wifi = "YES",
                    Ufaso_avtosadgomi = "NO",
                    otaxi_aramweveltaTvis = "NO",
                    bagi = "YES",
                    samrecxao = "YES",
                    terasa = "NO",
                    sabavsho_otaxi = "YES",
                    bari = "YES",
                    sakonferencio_darbazi = "NO",
                    kino_darbasi = "NO",
                    sauna = "YES",
                    daxuruli_auzi = "NO",
                    resotrani = "NO",
                    sabiliardo = "NO",
                    Shinauri_cxovelebis_dashveba = "YES",
                    spa_centri = "NO",
                    sportdarbazi = "YES"
                },
                   new TvisebebiSastumroebis
                   {
                       Tviseba_Id = 2,
                       Wifi = "NO",
                       Ufaso_avtosadgomi = "YES",
                       otaxi_aramweveltaTvis = "YES",
                       bagi = "NO",
                       samrecxao = "NO",
                       terasa = "YES",
                       sabavsho_otaxi = "NO",
                       bari = "NO",
                       sakonferencio_darbazi = "YES",
                       kino_darbasi = "YES",
                       sauna = "NO",
                       daxuruli_auzi = "YES",
                       resotrani = "YES",
                       sabiliardo = "YES",
                       Shinauri_cxovelebis_dashveba = "NO",
                       spa_centri = "YES",
                       sportdarbazi = "NO"
                   },
            new TvisebebiSastumroebis
            {
                Tviseba_Id = 3,
                Wifi = "YES",
                Ufaso_avtosadgomi = "NO",
                otaxi_aramweveltaTvis = "NO",
                bagi = "YES",
                samrecxao = "YES",
                terasa = "NO",
                sabavsho_otaxi = "YES",
                bari = "YES",
                sakonferencio_darbazi = "NO",
                kino_darbasi = "YES",
                sauna = "YES",
                daxuruli_auzi = "NO",
                resotrani = "NO",
                sabiliardo = "NO",
                Shinauri_cxovelebis_dashveba = "YES",
                spa_centri = "NO",
                sportdarbazi = "YES"
            },
            new TvisebebiSastumroebis
            {
                Tviseba_Id = 4,
                Wifi = "YES",
                Ufaso_avtosadgomi = "YES",
                otaxi_aramweveltaTvis = "NO",
                bagi = "NO",
                samrecxao = "YES",
                terasa = "YES",
                sabavsho_otaxi = "YES",
                bari = "NO",
                sakonferencio_darbazi = "YES",
                kino_darbasi = "NO",
                sauna = "YES",
                daxuruli_auzi = "NO",
                resotrani = "YES",
                sabiliardo = "YES",
                Shinauri_cxovelebis_dashveba = "NO",
                spa_centri = "YES",
                sportdarbazi = "NO"
            },
            new TvisebebiSastumroebis
            {
                Tviseba_Id = 5,
                Wifi = "NO",
                Ufaso_avtosadgomi = "NO",
                otaxi_aramweveltaTvis = "YES",
                bagi = "YES",
                samrecxao = "NO",
                terasa = "YES",
                sabavsho_otaxi = "YES",
                bari = "YES",
                sakonferencio_darbazi = "NO",
                kino_darbasi = "YES",
                sauna = "NO",
                daxuruli_auzi = "YES",
                resotrani = "NO",
                sabiliardo = "YES",
                Shinauri_cxovelebis_dashveba = "YES",
                spa_centri = "NO",
                sportdarbazi = "YES"
            },
            new TvisebebiSastumroebis
            {
                Tviseba_Id = 6,
                Wifi = "YES",
                Ufaso_avtosadgomi = "YES",
                otaxi_aramweveltaTvis = "NO",
                bagi = "NO",
                samrecxao = "YES",
                terasa = "NO",
                sabavsho_otaxi = "NO",
                bari = "YES",
                sakonferencio_darbazi = "NO",
                kino_darbasi = "YES",
                sauna = "YES",
                daxuruli_auzi = "NO",
                resotrani = "YES",
                sabiliardo = "NO",
                Shinauri_cxovelebis_dashveba = "YES",
                spa_centri = "NO",
                sportdarbazi = "YES"
            },
            new TvisebebiSastumroebis
            {
                Tviseba_Id = 7,
                Wifi = "NO",
                Ufaso_avtosadgomi = "NO",
                otaxi_aramweveltaTvis = "YES",
                bagi = "YES",
                samrecxao = "YES",
                terasa = "YES",
                sabavsho_otaxi = "YES",
                bari = "NO",
                sakonferencio_darbazi = "YES",
                kino_darbasi = "NO",
                sauna = "NO",
                daxuruli_auzi = "NO",
                resotrani = "YES",
                sabiliardo = "YES",
                Shinauri_cxovelebis_dashveba = "NO",
                spa_centri = "YES",
                sportdarbazi = "NO"
            },
            new TvisebebiSastumroebis
            {
                Tviseba_Id = 8,
                Wifi = "YES",
                Ufaso_avtosadgomi = "YES",
                otaxi_aramweveltaTvis = "NO",
                bagi = "NO",
                samrecxao = "YES",
                terasa = "NO",
                sabavsho_otaxi = "YES",
                bari = "YES",
                sakonferencio_darbazi = "NO",
                kino_darbasi = "YES",
                sauna = "YES",
                daxuruli_auzi = "NO",
                resotrani = "NO",
                sabiliardo = "YES",
                Shinauri_cxovelebis_dashveba = "NO",
                spa_centri = "YES",
                sportdarbazi = "NO"
            },
            new TvisebebiSastumroebis
            {
                Tviseba_Id = 9,
                Wifi = "NO",
                Ufaso_avtosadgomi = "NO",
                otaxi_aramweveltaTvis = "YES",
                bagi = "YES",
                samrecxao = "YES",
                terasa = "YES",
                sabavsho_otaxi = "NO",
                bari = "NO",
                sakonferencio_darbazi = "YES",
                kino_darbasi = "YES",
                sauna = "NO",
                daxuruli_auzi = "YES",
                resotrani = "YES",
                sabiliardo = "NO",
                Shinauri_cxovelebis_dashveba = "YES",
                spa_centri = "NO",
                sportdarbazi = "YES"
            },
            new TvisebebiSastumroebis
            {
                Tviseba_Id = 10,
                Wifi = "YES",
                Ufaso_avtosadgomi = "YES",
                otaxi_aramweveltaTvis = "NO",
                bagi = "NO",
                samrecxao = "YES",
                terasa = "NO",
                sabavsho_otaxi = "YES",
                bari = "YES",
                sakonferencio_darbazi = "NO",
                kino_darbasi = "YES",
                sauna = "NO",
                daxuruli_auzi = "YES",
                resotrani = "NO",
                sabiliardo = "YES",
                Shinauri_cxovelebis_dashveba = "NO",
                spa_centri = "YES",
                sportdarbazi = "NO"
            });
			modelBuilder.Entity<UserAndTurebiMap>().HasKey(u => new { u.Turebi_Id, u.User_Id });
            modelBuilder.Entity<Turebi>().HasOne(u => u.Company).WithMany(u => u.Turebi).HasForeignKey(u => u.Company_Id);
            modelBuilder.Entity<UserAndTurebiMap>().HasOne(u => u.turebi).WithMany(u => u.UserAndTurebiMapT).HasForeignKey(u => u.Turebi_Id);
            modelBuilder.Entity<UserAndTurebiMap>().HasOne(u => u.User).WithMany(u => u.UserAndTurebiMapU).HasForeignKey(u => u.User_Id);
            modelBuilder.Entity<Sastumroebi>().HasOne(u => u.tvisebebiSastumroebis).WithOne(u => u.Sastumro);
            modelBuilder.Entity<UserAndSastumroebi>().HasKey(u => new { u.Sastumorebi_Id, u.User_Id });
            modelBuilder.Entity<UserAndSastumroebi>().HasOne(u => u.sastumroebi).WithMany(u => u.user_sastumroebi).HasForeignKey(u => u.Sastumorebi_Id);
            modelBuilder.Entity<UserAndSastumroebi>().HasOne(u => u.users).WithMany(u => u.user_sastumroebi).HasForeignKey(u => u.User_Id);

         
            modelBuilder.Entity<Sastumroebi>().HasMany(u=>u.Tvisebebis_Sastumroebi).WithOne(u=>u.Sastumro).HasForeignKey(u=>u.Sastumros_Id);
        }
        

    }
}
