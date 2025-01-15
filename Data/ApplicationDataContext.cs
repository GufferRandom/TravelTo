using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelTo.Models;

namespace TravelTo.Data
{
    public class ApplicationDataContext : IdentityDbContext<User>
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Turebi> Turebis { get; set; }
        public DbSet<UserAndTurebiMap> UserAndTurebi { get; set; }
        public DbSet<ContactPerson> ContactiUndat { get; set; }
        public DbSet<Sastumroebi> Sastumroebis { get; set; }
        public DbSet<TvisebebiSastumroebis> TvisebebiDaSastumroebi { get; set; }
        public DbSet<UserAndSastumroebi> userAndSastumroebis { get; set; }
        public DbSet<SastumroDajavshna> sastumroDajavshna { get; set; }
        public DbSet<SastumroebiDaTurebi> Sastumrodaturebi { get; set; }
        public DbSet<SastumtroAndDajavshna> SastumtroAndDajavshna { get; set; }
        public DbSet<SastumroCapitacity> SastumroCapitacity { get; set; }
        public DbSet<SastumroebiDaTurebi> SastumroebiDaTurebi { get; set; }
        public DbSet<UserCookie> userCookies { get; set; }
        public DbSet<UserCookieTurebi> userCookieTurebis { get; set; }
        public DbSet<UserSastumroebiCookies> userSastumroebiCookies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Company_Id = 1,
                    owner = "gela",
                    description = "saswauli kompania romelic arasdros iarsebs",
                    Name = "TBCKVADRO",
                    img_name = "tbc_image.png"
                },
                new Company
                {
                    Company_Id = 2,
                    owner = "NEKA",
                    description = "raxdeba sh",
                    Name = "liberti",
                    img_name = "liberti_img.png"
                },
                new Company
                {
                    Company_Id = 3,
                    owner = "NAK",
                    description = "imedia",
                    Name = "bog",
                    img_name = "bog_image.png"
                },
                new Company
                {
                    Company_Id = 4,
                    owner = "bark",
                    description = "iarsebs",
                    Name = "kripto",
                    img_name = "credit_bank.png"
                }
            );
            modelBuilder.Entity<Turebi>().HasData(
                new Turebi
                {
                    id = 1,
                    Name = "ანტარქტიდა",
                    Description = "ანტარქტიდა დედამიწის ყველაზე სამხრეთული კონტინენტია, სადაც არ არსებობს მუდმივი მოსახლეობა, მხოლოდ მკვლევარები.",
                    Price = 999.99,
                    image_name = "antarqtida.jpg",
                    Company_Id = 1
                },
                new Turebi
                {
                    id = 2,
                    Name = "თბილისი",
                    Description = "თბილისი საქართველოს დედაქალაქია, ცნობილია თავისი ისტორიული ძველი უბნებით და კულტურული მნიშვნელობით.",
                    Price = 500.99,
                    image_name = "Tbilisi.jpg",
                    Company_Id = 3
                },
                new Turebi
                {
                    id = 3,
                    Name = "ქუთაისი",
                    Description = "ქუთაისი საქართველოს ისტორიული ქალაქია, გალიას საკათედრო ტაძრითა და მსოფლიოს ერთ-ერთი ძველი უნივერსიტეტით.",
                    Price = 799.99,
                    image_name = "7012519385_f7e92b8d8e_z.jpg",
                    Company_Id = 2
                },
                new Turebi
                {
                    id = 4,
                    Name = "პარიზი",
                    Description = "პარიზი საფრანგეთის დედაქალაქია, ცნობილია აიფელის კოშკით და ლუვრის მუზეუმით.",
                    Price = 1999.99,
                    image_name = "Spain.jfif",
                    Company_Id = 4
                },
                new Turebi
                {
                    id = 5,
                    Name = "ბათუმი",
                    Description = "ბათუმი შავი ზღვის სანაპიროზე მდებარე ქალაქია, ცნობილი თავისი სანაპირო პარკებით და კურორტებით.",
                    Price = 999.99,
                    image_name = "Batumi.jpg",
                    Company_Id = 1
                },
                new Turebi
                {
                    id = 6,
                    Name = "მაიამი",
                    Description = "მაიამი, აშშ-ის ფლორიდაში მდებარე ქალაქია, ცნობილი თავისი ფინანსური, კულტურული და სავაჭრო ცენტრის როლით.",
                    Price = 1999.99,
                    image_name = "Brazil.jfif",
                    Company_Id = 2
                },
                new Turebi
                {
                    id = 7,
                    Name = "გორი",
                    Description = "გორი ქალაქია საქართველოში, ცნობილია თავისი ისტორიული მნიშვნელობით და გორის ციხით.",
                    Price = 500.99,
                    image_name = "Denmark.jfif",
                    Company_Id = 4
                },
                new Turebi
                {
                    id = 8,
                    Name = "თელავი",
                    Description = "თელავი ქალაქია კახეთში, ცნობილი თავისი ღვინის კულტურით და ისტორიული ძეგლებით.",
                    Price = 999.99,
                    image_name = "Los-AngelesCa.jfif",
                    Company_Id = 3
                }
            );
            modelBuilder.Entity<Sastumroebi>().HasData(
                new Sastumroebi
                {
                    Id = 1,
                    Lokacia = "თბილისი",
                    Fasi = 100,
                    Description = "ეს სასტუმრო წარმოადგენს სამგზის ლუქსს და თანამედროვე მომსახურებას.",
                    gmail = "tbilisi@gmail.com",
                    Name = "თბილისის ცენტრალური სასტუმრო",
                    image_name = "1.jpeg",
                    Tviseba_Id = 1
                },
                new Sastumroebi
                {
                    Id = 2,
                    Lokacia = "ბათუმი",
                    Fasi = 50,
                    Description = "ამ სასტუმროში სტუმრები სარგებლობენ საოცარი სანაპიროს ხედებით.",
                    gmail = "batumi@gmail.com",
                    Name = "ბათუმი რეზორტი",
                    image_name = "2.jpg",
                    Tviseba_Id = 2
                },
                new Sastumroebi
                {
                    Id = 3,
                    Lokacia = "ქუთაისი",
                    Fasi = 75,
                    Description = "სასტუმრო გთავაზობთ კომფორტულ პირობებს და შესანიშნავ სამზარეულოს.",
                    gmail = "kutaisi@gmail.com",
                    Name = "ქუთაისი  სასტუმრო",
                    image_name = "3.jpg",
                    Tviseba_Id = 3
                },
                new Sastumroebi
                {
                    Id = 4,
                    Lokacia = "მცხეთა",
                    Fasi = 60,
                    Description = "სასტუმრო წარმოადგენს ისტორიულ და კულტურულ გარემოს.",
                    gmail = "mtskheta@gmail.com",
                    Name = "მცხეთა ჰერიტიჯ სასტუმრო",
                    image_name = "4.webp",
                    Tviseba_Id = 4
                },
                new Sastumroebi
                {
                    Id = 5,
                    Lokacia = "ზუგდიდი",
                    Fasi = 80,
                    Description = "ცენტრალური ადგილმდებარეობა, ახლოს სამრეწველო და კულტურული ატრაქციონებთან.",
                    gmail = "zugdidi@gmail.com",
                    Name = "ზუგდიდი პარკ სასტუმრო",
                    image_name = "5.jpg",
                    Tviseba_Id = 5
                },
                new Sastumroebi
                {
                    Id = 6,
                    Lokacia = "გორი",
                    Fasi = 40,
                    Description = "მომსახურება მაღალი ხარისხის, მყუდრო ატმოსფერო და თანამედროვე ოთახები.",
                    gmail = "gori@gmail.com",
                    Name = "გორი ფორტეს სასტუმრო",
                    image_name = "6.jpg",
                    Tviseba_Id = 6
                },
                new Sastumroebi
                {
                    Id = 7,
                    Lokacia = "თელავი",
                    Fasi = 30,
                    Description = "თელავში მდებარე მყუდრო სასტუმრო, რომელიც გთავაზობთ შესანიშნავ მომსახურებას.",
                    gmail = "telavi@gmail.com",
                    Name = "თელავი უაინ ჰოტელი",
                    image_name = "7.jpg",
                    Tviseba_Id = 7
                },
                new Sastumroebi
                {
                    Id = 8,
                    Lokacia = "სიღნაღი",
                    Fasi = 45,
                    Description = "სასტუმრო მაღალი ხარისხის მომსახურებითა და ლამაზი ხედებით.",
                    gmail = "signagi@gmail.com",
                    Name = "სიღნაღი ჰილტოპ სასტუმრო",
                    image_name = "8.jpg",
                    Tviseba_Id = 8
                },
                new Sastumroebi
                {
                    Id = 9,
                    Lokacia = "რაჭა",
                    Fasi = 55,
                    Description = "სასტუმრო მშვიდ გარემოში და სრულყოფილი მყუდროებით.",
                    gmail = "racha@gmail.com",
                    Name = "რაჭა რეზორტი",
                    image_name = "9.jpg",
                    Tviseba_Id = 9
                },
                new Sastumroebi
                {
                    Id = 10,
                    Lokacia = "ვარძი",
                    Fasi = 65,
                    Description = "ვარძი ჰოტელი გთავაზობთ თანამედროვე ფასის ოპციებს და განსაცვიფრებელ გარემოს.",
                    gmail = "vardzi@gmail.com",
                    Name = "ვარძი რეზორტი",
                    image_name = "10.jpg",
                    Tviseba_Id = 10
                }
            );

            modelBuilder.Entity<SastumroebiDaTurebi>().HasData(
                new SastumroebiDaTurebi { Sastumro_Id = 2, Turebi_Id = 1 },
                new SastumroebiDaTurebi { Sastumro_Id = 3, Turebi_Id = 2 },
                new SastumroebiDaTurebi { Sastumro_Id = 4, Turebi_Id = 3 },
                new SastumroebiDaTurebi { Sastumro_Id = 1, Turebi_Id = 8 },
                new SastumroebiDaTurebi { Sastumro_Id = 10, Turebi_Id = 4 },
                new SastumroebiDaTurebi { Sastumro_Id = 9, Turebi_Id = 7 },
                new SastumroebiDaTurebi { Sastumro_Id = 8, Turebi_Id = 6 },
                new SastumroebiDaTurebi { Sastumro_Id = 5, Turebi_Id = 5 }
            );
            modelBuilder.Entity<TvisebebiSastumroebis>().HasData(
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 1,
        Wifi = "YES",
        უფასო_ავტოსადგომი = "NO",
        ოთახი_არამწეველებისთვის = "NO",
        ბაღი = "YES",
        სამრეცხაო = "YES",
        ტერასა = "NO",
        საბავშო_ოთახი = "YES",
        ბარი = "YES",
        საკონფერენციო_დარბაზი = "NO",
        კინოდარბაზი = "NO",
        საუნა = "YES",
        უფასო_წყალი = "NO",
        რესტორანი = "NO",
        ბილიარდი = "NO",
        შინაური_ცხოვრების_დაშვება = "YES",
        სპა_ცენტრი = "NO",
        სპორტული_დარბაზი = "YES"
    },
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 2,
        Wifi = "NO",
        უფასო_ავტოსადგომი = "YES",
        ოთახი_არამწეველებისთვის = "YES",
        ბაღი = "NO",
        სამრეცხაო = "NO",
        ტერასა = "YES",
        საბავშო_ოთახი = "NO",
        ბარი = "NO",
        საკონფერენციო_დარბაზი = "YES",
        კინოდარბაზი = "YES",
        საუნა = "NO",
        უფასო_წყალი = "YES",
        რესტორანი = "YES",
        ბილიარდი = "YES",
        შინაური_ცხოვრების_დაშვება = "NO",
        სპა_ცენტრი = "YES",
        სპორტული_დარბაზი = "NO"
    },
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 3,
        Wifi = "YES",
        უფასო_ავტოსადგომი = "NO",
        ოთახი_არამწეველებისთვის = "NO",
        ბაღი = "YES",
        სამრეცხაო = "YES",
        ტერასა = "NO",
        საბავშო_ოთახი = "YES",
        ბარი = "YES",
        საკონფერენციო_დარბაზი = "NO",
        კინოდარბაზი = "YES",
        საუნა = "YES",
        უფასო_წყალი = "NO",
        რესტორანი = "NO",
        ბილიარდი = "NO",
        შინაური_ცხოვრების_დაშვება = "YES",
        სპა_ცენტრი = "NO",
        სპორტული_დარბაზი = "YES"
    },
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 4,
        Wifi = "YES",
        უფასო_ავტოსადგომი = "YES",
        ოთახი_არამწეველებისთვის = "NO",
        ბაღი = "NO",
        სამრეცხაო = "YES",
        ტერასა = "YES",
        საბავშო_ოთახი = "YES",
        ბარი = "NO",
        საკონფერენციო_დარბაზი = "YES",
        კინოდარბაზი = "NO",
        საუნა = "YES",
        უფასო_წყალი = "NO",
        რესტორანი = "YES",
        ბილიარდი = "YES",
        შინაური_ცხოვრების_დაშვება = "NO",
        სპა_ცენტრი = "YES",
        სპორტული_დარბაზი = "NO"
    },
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 5,
        Wifi = "NO",
        უფასო_ავტოსადგომი = "NO",
        ოთახი_არამწეველებისთვის = "YES",
        ბაღი = "YES",
        სამრეცხაო = "NO",
        ტერასა = "YES",
        საბავშო_ოთახი = "YES",
        ბარი = "YES",
        საკონფერენციო_დარბაზი = "NO",
        კინოდარბაზი = "YES",
        საუნა = "NO",
        უფასო_წყალი = "YES",
        რესტორანი = "NO",
        ბილიარდი = "YES",
        შინაური_ცხოვრების_დაშვება = "YES",
        სპა_ცენტრი = "NO",
        სპორტული_დარბაზი = "YES"
    },
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 6,
        Wifi = "YES",
        უფასო_ავტოსადგომი = "YES",
        ოთახი_არამწეველებისთვის = "NO",
        ბაღი = "NO",
        სამრეცხაო = "YES",
        ტერასა = "NO",
        საბავშო_ოთახი = "NO",
        ბარი = "YES",
        საკონფერენციო_დარბაზი = "NO",
        კინოდარბაზი = "YES",
        საუნა = "YES",
        უფასო_წყალი = "NO",
        რესტორანი = "YES",
        ბილიარდი = "NO",
        შინაური_ცხოვრების_დაშვება = "YES",
        სპა_ცენტრი = "NO",
        სპორტული_დარბაზი = "YES"
    },
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 7,
        Wifi = "NO",
        უფასო_ავტოსადგომი = "NO",
        ოთახი_არამწეველებისთვის = "YES",
        ბაღი = "YES",
        სამრეცხაო = "YES",
        ტერასა = "YES",
        საბავშო_ოთახი = "YES",
        ბარი = "NO",
        საკონფერენციო_დარბაზი = "YES",
        კინოდარბაზი = "NO",
        საუნა = "NO",
        უფასო_წყალი = "NO",
        რესტორანი = "YES",
        ბილიარდი = "YES",
        შინაური_ცხოვრების_დაშვება = "NO",
        სპა_ცენტრი = "YES",
        სპორტული_დარბაზი = "NO"
    },
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 8,
        Wifi = "YES",
        უფასო_ავტოსადგომი = "YES",
        ოთახი_არამწეველებისთვის = "NO",
        ბაღი = "NO",
        სამრეცხაო = "YES",
        ტერასა = "NO",
        საბავშო_ოთახი = "YES",
        ბარი = "YES",
        საკონფერენციო_დარბაზი = "NO",
        კინოდარბაზი = "YES",
        საუნა = "YES",
        უფასო_წყალი = "NO",
        რესტორანი = "NO",
        ბილიარდი = "YES",
        შინაური_ცხოვრების_დაშვება = "NO",
        სპა_ცენტრი = "YES",
        სპორტული_დარბაზი = "NO"
    },
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 9,
        Wifi = "NO",
        უფასო_ავტოსადგომი = "NO",
        ოთახი_არამწეველებისთვის = "YES",
        ბაღი = "YES",
        სამრეცხაო = "YES",
        ტერასა = "YES",
        საბავშო_ოთახი = "NO",
        ბარი = "NO",
        საკონფერენციო_დარბაზი = "YES",
        კინოდარბაზი = "YES",
        საუნა = "NO",
        უფასო_წყალი = "YES",
        რესტორანი = "YES",
        ბილიარდი = "NO",
        შინაური_ცხოვრების_დაშვება = "YES",
        სპა_ცენტრი = "NO",
        სპორტული_დარბაზი = "YES"
    },
    new TvisebebiSastumroebis
    {
        Tviseba_Id = 10,
        Wifi = "YES",
        უფასო_ავტოსადგომი = "YES",
        ოთახი_არამწეველებისთვის = "NO",
        ბაღი = "NO",
        სამრეცხაო = "YES",
        ტერასა = "NO",
        საბავშო_ოთახი = "YES",
        ბარი = "YES",
        საკონფერენციო_დარბაზი = "NO",
        კინოდარბაზი = "YES",
        საუნა = "NO",
        უფასო_წყალი = "YES",
        რესტორანი = "NO",
        ბილიარდი = "YES",
        შინაური_ცხოვრების_დაშვება = "NO",
        სპა_ცენტრი = "YES",
        სპორტული_დარბაზი = "NO"
    });

            modelBuilder.Entity<SastumroCapitacity>().HasData(new SastumroCapitacity
            {
                Id = 1,
                Sastumro_Id = 1,
                MaxCapitacity = 50,
                CurrentCapacity = 0,
            }, new SastumroCapitacity
            {
                Id = 2,
                Sastumro_Id = 2,
                MaxCapitacity = 100,
                CurrentCapacity = 0,
            }, new SastumroCapitacity
            {
                Id = 3,
                Sastumro_Id = 3,
                MaxCapitacity = 200,
                CurrentCapacity = 0,
            }, new SastumroCapitacity
            {
                Id = 4,
                Sastumro_Id = 4,
                MaxCapitacity = 300,
                CurrentCapacity = 0,
            }, new SastumroCapitacity
            {
                Id = 5,
                Sastumro_Id = 5,
                MaxCapitacity = 50,
                CurrentCapacity = 0,
            }, new SastumroCapitacity
            {
                Id = 6,
                Sastumro_Id = 6,
                MaxCapitacity = 200,
                CurrentCapacity = 0,
            }, new SastumroCapitacity
            {
                Id = 7,
                Sastumro_Id = 7,
                MaxCapitacity = 300,
                CurrentCapacity = 0,
            }, new SastumroCapitacity
            {
                Id = 8,
                Sastumro_Id = 8,
                MaxCapitacity = 300,
                CurrentCapacity = 0,
            }, new SastumroCapitacity
            {
                Id = 9,
                Sastumro_Id = 9,
                MaxCapitacity = 100,
                CurrentCapacity = 0,
            }, new SastumroCapitacity
            {
                Id = 10,
                Sastumro_Id = 10,
                MaxCapitacity = 2,
                CurrentCapacity = 0,
            }
            );
            modelBuilder.Entity<UserAndTurebiMap>().HasKey(u => new { u.Turebi_Id, u.User_Id });
            modelBuilder.Entity<Turebi>().HasOne(u => u.Company).WithMany(u => u.Turebi).HasForeignKey(u => u.Company_Id);
            modelBuilder.Entity<UserAndTurebiMap>().HasOne(u => u.turebi).WithMany(u => u.UserAndTurebiMapT).HasForeignKey(u => u.Turebi_Id);
            modelBuilder.Entity<UserAndTurebiMap>().HasOne(u => u.User).WithMany(u => u.UserAndTurebiMapU).HasForeignKey(u => u.User_Id);
            modelBuilder.Entity<Sastumroebi>().HasOne(u => u.tvisebebiSastumroebis).WithOne(u => u.Sastumro);
            modelBuilder.Entity<UserAndSastumroebi>().HasKey(u => new { u.Sastumorebi_Id, u.User_Id });
            modelBuilder.Entity<UserAndSastumroebi>().HasOne(u => u.sastumroebi).WithMany(u => u.user_sastumroebi).HasForeignKey(u => u.Sastumorebi_Id);
            modelBuilder.Entity<UserAndSastumroebi>().HasOne(u => u.users).WithMany(u => u.user_sastumroebi).HasForeignKey(u => u.User_Id);
            modelBuilder.Entity<SastumroebiDaTurebi>().HasKey(u => new { u.Sastumro_Id, u.Turebi_Id });
            modelBuilder.Entity<SastumroebiDaTurebi>().HasOne(u => u.Turebi).WithMany(u => u.Sastumroebi).HasForeignKey(u => u.Turebi_Id);
            modelBuilder.Entity<SastumroebiDaTurebi>().HasOne(u => u.Sastumroebi).WithMany(u => u.turebi).HasForeignKey(u => u.Sastumro_Id);
            modelBuilder.Entity<SastumtroAndDajavshna>().HasKey(u => new { u.Sastumro_Id, u.SastumroDajavshna_Id });
            modelBuilder.Entity<SastumtroAndDajavshna>().HasOne(u => u.Sastumroebi).WithMany(u => u.SastumroAndDajavshna).HasForeignKey(u => u.Sastumro_Id);
            modelBuilder.Entity<SastumtroAndDajavshna>().HasOne(u => u.sastumroDajavshna).WithMany(u => u.SastumroAndDajavshna).HasForeignKey(u => u.SastumroDajavshna_Id);
            modelBuilder.Entity<SastumroCapitacity>().HasOne(u => u.Sastumroebi).WithOne(u => u.sastumroCapitacity).HasForeignKey<SastumroCapitacity>(u => u.Sastumro_Id);
            modelBuilder.Entity<UserCookieTurebi>().HasKey(u => new { u.Turebi_Id, u.User_Id});
            modelBuilder.Entity<UserCookieTurebi>().HasOne(u => u.Turebi).WithMany(u => u.UserCookieTurebi).HasForeignKey(u => u.Turebi_Id);
            modelBuilder.Entity<UserCookieTurebi>().HasOne(u => u.UserCookie).WithMany(u => u.UserCookieTurebis).HasForeignKey(u => u.User_Id);
            modelBuilder.Entity<UserSastumroebiCookies>().HasKey(u => new { u.Sastumro_Id, u.User_Id } );
            modelBuilder.Entity<UserSastumroebiCookies>().HasOne(u=>u.Sastumroebi).WithMany(u=>u.sastumroAndCookies).HasForeignKey(u=> u.Sastumro_Id);
            modelBuilder.Entity<UserSastumroebiCookies>().HasOne(u=>u.UserCookie).WithMany(u=>u.UserSastumroebiCookies).HasForeignKey(u => u.User_Id);

        }

    }
}
