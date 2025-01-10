using Humanizer;
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
        public DbSet<SastumroDajavshna> sastumroDajavshna { get; set; }
        public DbSet<SastumroebiDaTurebi> Sastumrodaturebi { get; set; }
        public DbSet<SastumtroAndDajavshna> SastumtroAndDajavshna { get; set; }
        public DbSet<SastumroCapitacity> SastumroCapitacity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Company_Id = 1, owner = "gela", description = "saswauli kompania romelic arasdros iarsebs",
                    Name = "TBCKVADRO", img_name = "tbc_image.png"
                },
                new Company
                {
                    Company_Id = 2, owner = "NEKA", description = "raxdeba sh", Name = "liberti",
                    img_name = "liberti_img.png"
                },
                new Company
                {
                    Company_Id = 3, owner = "NAK", description = "imedia", Name = "bog", img_name = "bog_image.png"
                },
                new Company
                {
                    Company_Id = 4, owner = "bark", description = "iarsebs", Name = "kripto",
                    img_name = "credit_bank.png"
                }
            );
            modelBuilder.Entity<Turebi>().HasData(
                new Turebi
                {
                    id = 1, Name = "ანტარქტიდა", Description = "ანტარქტიდა — დედამიწის ყველაზე მაღალი კონტინენტია, რომლის ზედაპირის საშუალო სიმაღლე ზღვის დონიდან შეადგენს 2000 მეტრზე მეტს, ხოლო კონტინენტის ცენტრში აღწევს 4000 მეტრს.", 
                    Price = 999.99,
                    image_name = "antarqtida.jpg", Company_Id = 1
                },
                new Turebi
                {
                    id = 2, Name = "თბილისი", Description = "თბილისი კავკასიის რეგიონის მნიშვნელოვანი ინდუსტრიული, სოციალური და კულტურული ცენტრია და ბოლო დროს ერთ-ერთი უმნიშვნელოვანესი სატრანსპორტო კვანძი ხდება გლობალური ენერგომატარებლებისა და სავაჭრო პროექტებისთვის (იხ. ბაქო-თბილისი-ჯეიჰანის ნავთობსადენი და ბაქო-თბილისი-ერზერუმის გაზსადენი). ქალაქი ისტორიული აბრეშუმის დიდი გზის ერთ-ერთ მარშრუტზე მდებარეობს და მნიშვნელოვანი სავაჭრო/სატრანზიტო ცენტრის პოზიცია უჭირავს რუსეთის ჩრდილო კავკასიას, " +
                    "თურქეთსა და ტრანსკავკასიის სომხეთისა და აზერბაიჯანის რესპუბლიკების გადაკვეთაზე სტრატეგიული მდებარეობით.", Price = 500.99, image_name = "Tbilisi.jpg",
                    Company_Id = 3
                },
                new Turebi
                {
                    id = 3, Name = "ქუთაისი", Description = "ქუთაისი — ქალაქი და მუნიციპალიტეტი საქართველოში, იმერეთის მხარის ადმინისტრაციული ცენტრი, სიდიდით მეოთხე ქალაქი საქართველოში, საქართველოს სამეფოს ისტორიული დედაქალაქი, ქუთაისის " +
                    "საეპისკოპოსოს ისტორიული ცენტრი. მდებარეობს მდინარე რიონზე. მოსახლეობა 130 400 ადამიანი (2023). ", Price =799.99,
                    image_name = "7012519385_f7e92b8d8e_z.jpg", Company_Id = 2
                },
                new Turebi
                {
                    id = 4, Name = "პარიზი", Description = "პარიზი (ფრანგ. Paris [paˈʁi] პაღი) — საფრანგეთის დედაქალაქი და ქვეყნის უდიდესი ქალაქია, ასევე ადმინისტრაციული ცენტრი ილ-დე-ფრანსის რეგიონის, რომელიც მოიცავს პარიზსა და მის შემოგარენს. პარიზი ევროპის წამყვანი კულტურული, ბიზნეს და პოლიტიკური ცენტრია, დამახასიათებელი ნეოკლასიკური არქიტექტურითა და მისი გავლენით მოდასა და ხელოვნებაზე. მეტსახელად „სინათლის ქალაქი“ (la Ville Lumière)," +
                    " პარიზი XIX საუკუნიდან მოყოლებული ყველაზე რომანტიკული ქალაქის რეპუტაციით სარგებლობს. ", Price = 1999.99,
                    image_name = "Los-AngelesCa.jfif", Company_Id = 4
                },
                new Turebi
                {
                    id = 5, Name = "ბათუმი", Description = "ბათუმი — ქალაქი და მუნიციპალიტეტი[5] საქართველოში, არის აჭარის ავტონომიური რესპუბლიკის ადმინისტრაციული ცენტრი. ბათუმი არის მოსახლეობის რაოდენობით მეორე ქალაქი საქართველოში, მსხვილი საერთაშორისო ნავსადგური შავი ზღვის სამხრეთ-აღმოსავლეთ" +
                    " სანაპიროზე, მნიშვნელოვანი სამრეწველო, კულტურული და ტურისტული ცენტრი საქართველოში. ", Price = 999.99, image_name = "Batumi.jpg",
                    Company_Id = 1
                },
                new Turebi
                {
                    id = 6, Name = "მაიამი", Description = "მაიამი (ინგლ. Miami) — ქალაქი აშშ-ში, ფლორიდის შტატში. მდებარეობს შტატის სამხრეთ-აღმოსავლეთ ნაწილში, ატლანტის ოკეანის სანაპიროზე. 2013 წლის მონაცემებით მოსახლეობა 417,650 კაცი. ფორბსი მაიამი მოწინავე ქალაქია ფინანსების, კომერციის, კულტურის, მედიის, ხელოვნებისა და საერთაშორისო ვაჭრობის სექტორებში. მაიამის პორტი ცნობილია როგორც „მსოფლიოს კრუიზული დედაქალაქი“.[1] მაიამის პორტს ჰყავს მსოფლიოში ყველაზე მეტი კრუიზული ხაზი და მგზავრები.[2] 2010 წელს მაიამი შეფასდა როგორც მეშვიდე ყველაზე მნიშვნელოვანი ქალაქი აშშ-ში და 33-ე მსოფლიოში. 2008 წელს მაიამი ფორბსის მიერ შეფასდა როგორც „ამერიკის უსუფთავესი ქალაქი“. 2009 წელს ცნობილმა შვეიცარიულმა ბანკმა იუ-ბი-ესმა შეისწავლა მსოფლიოს 73 უმდიდრესი ქალაქი " +
                    "და მაიამი შეაფასა როგორც ყველაზე მდიდარი ქალაქი აშშ-ში, ხოლო მეთხუთმეტე უმდიდრესი ქალაქი მსოფლიოში.[3] ", Price = 1999.99, image_name = "Brazil.jfif",
                    Company_Id = 2
                },
                new Turebi
                {
                    id = 7, Name = "გორი", Description = "გორი — ქალაქი საქართველოში, შიდა ქართლის მხარეში, გორის მუნიციპალიტეტისა და შიდა ქართლის მხარის ადმინისტრაციული ცენტრი. მდებარეობს მდინარეების მტკვრისა და ლიახვის შესართავთან, " +
                    "ძირითად სატრანსპორტო გზების გზასაყარზე, თბილისიდან 76-ე კილომეტრში (რკინიგზით).", Price = 500.99,
                    image_name = "Denmark.jfif", Company_Id = 4
                },
                new Turebi
                {
                    id = 8, Name = "თელავი", Description = "მთელავი — ქალაქი საქართველოში, კახეთის მხარისა" +
                    " და თელავის მუნიციპალიტეტის ადმინისტრაციული ცენტრი. მოსახლეობა 19 629 (2014 წ.) ადამიანი. ", Price = 999.99, image_name = "Spain.jfif",
                    Company_Id = 3
                }
            );
            modelBuilder.Entity<Sastumroebi>().HasData(
                new Sastumroebi
                {
                    Id = 1, Lokacia = "RobotiqsiHotel", Fasi = 100,
                    Description = "es sastumro mdebareobs dedamiwis mwervalze romelzedac iyo guini",
                    gmail = "gmail@gmail.com", Name = "Robotiqsi Grand Hotel", image_name = "1.jpeg", Tviseba_Id = 1
                },
                new Sastumroebi
                {
                    Id = 2, Lokacia = "AntarqtidaHotel", Fasi = 50,
                    Description = "Es sastumro mdebareobs msoflios yvelaze civ wertislhi wesit esaaa",
                    gmail = "antarqtida@gmail.com", Name = "Antarqtida Luxury Suites", image_name = "2.jpg",
                    Tviseba_Id = 2
                },
                new Sastumroebi
                {
                    Id = 3, Lokacia = "TbilisiHotel", Fasi = 75,
                    Description = "Tbilisi tbilisi tbilisi uni uni uni btu ilia japan tsu.",
                    gmail = "tbilisi@gmail.com", Name = "Tbilisi City Hotel", image_name = "3.jpg", Tviseba_Id = 3
                },
                new Sastumroebi
                {
                    Id = 4, Lokacia = "KutaisiHotel", Fasi = 60,
                    Description = "Kutaisi kutaisi kutaisi ratqmaunda kutasisi rogorc yoveltvbis kutaisi.",
                    gmail = "kutaisi@gmail.com", Name = "Kutaisi Boutique Hotel", image_name = "4.webp", Tviseba_Id = 4
                },
                new Sastumroebi
                {
                    Id = 5, Lokacia = "BatumiHotel", Fasi = 80,
                    Description = "Batumi bautmi bautmi zfgva zgva zgva meti meti meti.", gmail = "batumi@gmail.com",
                    Name = "Batumi Beach Resort", image_name = "5.jpg", Tviseba_Id = 5
                },
                new Sastumroebi
                {
                    Id = 6, Lokacia = "MtskhetaHotel", Fasi = 40,
                    Description = "Mtskheta es xom mcxetaa mcxetaa azrze ar var ra davwero amaze.",
                    gmail = "mtskheta@gmail.com", Name = "Mtskheta Heritage Inn", image_name = "6.jpg", Tviseba_Id = 6
                },
                new Sastumroebi
                {
                    Id = 7, Lokacia = "ZugdidiHotel", Fasi = 30,
                    Description = "Zugdidi es xom zugdidia yvelaze didi farti romelic daixarja",
                    gmail = "zugdidi@gmail.com", Name = "Zugdidi Park Hotel", image_name = "7.jpg", Tviseba_Id = 7
                },
                new Sastumroebi
                {
                    Id = 8, Lokacia = "GoriHotel", Fasi = 45,
                    Description = "Gori gori gori amis meti ra unda vtqva es xom goria gorta shoris.",
                    gmail = "gori@gmail.com", Name = "Gori Fortress Hotel", image_name = "8.jpg", Tviseba_Id = 8
                },
                new Sastumroebi
                {
                    Id = 9, Lokacia = "TelaviHotel", Fasi = 55,
                    Description = "Telavi telavi telavi azrze ar var ra davwero amashi mara telaviaMountains.",
                    gmail = "telavi@gmail.com", Name = "Telavi Wine Hotel", image_name = "9.jpg", Tviseba_Id = 9
                },
                new Sastumroebi
                {
                    Id = 10, Lokacia = "SignagiHotel", Fasi = 65,
                    Description =
                        "Signagi signagi signagi es xom signagia azrze ar var ra davwero amazec amitomac signagi signagia.",
                    gmail = "signagi@gmail.com", Name = "Signagi Hilltop Hotel", image_name = "10.jpg", Tviseba_Id = 10
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
            modelBuilder.Entity<SastumroebiDaTurebi>().HasKey(u => new {u.Sastumro_Id,u.Turebi_Id});
            modelBuilder.Entity<SastumroebiDaTurebi>().HasOne(u => u.Turebi).WithMany(u => u.Sastumroebi).HasForeignKey(u => u.Turebi_Id);
            modelBuilder.Entity<SastumroebiDaTurebi>().HasOne(u => u.Sastumroebi).WithMany(u => u.turebi).HasForeignKey(u => u.Sastumro_Id);
            modelBuilder.Entity<SastumtroAndDajavshna>().HasKey(u => new { u.Sastumro_Id, u.SastumroDajavshna_Id });
            modelBuilder.Entity<SastumtroAndDajavshna>().HasOne(u => u.Sastumroebi).WithMany(u => u.SastumroAndDajavshna).HasForeignKey(u => u.Sastumro_Id);
            modelBuilder.Entity<SastumtroAndDajavshna>().HasOne(u => u.sastumroDajavshna).WithMany(u => u.SastumroAndDajavshna).HasForeignKey(u => u.SastumroDajavshna_Id);
            modelBuilder.Entity<SastumroCapitacity>().HasOne(u=>u.Sastumroebi).WithOne(u=>u.sastumroCapitacity).HasForeignKey<SastumroCapitacity>(u=>u.Sastumro_Id);
        }
        
    }
}
