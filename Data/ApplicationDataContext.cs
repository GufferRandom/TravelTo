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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Company>().HasData(
                new Company { Company_Id = 1, owner = "gela", description = "saswauli kompania romelic arasdros iarsebs", Name = "TBCKVADRO" ,img_name= "tbc_image.png" },
                new Company { Company_Id = 2, owner = "NEKA", description = "raxdeba sh", Name = "liberti", img_name="liberti_img.png" },
                new Company { Company_Id = 3, owner = "NAK", description = "imedia", Name = "bog",img_name= "bog_image.png" },
                new Company { Company_Id = 4, owner = "bark", description = "iarsebs", Name = "kripto",img_name= "credit_bank.png" }
                );
            modelBuilder.Entity<Turebi>().HasData(
                new Turebi { id = 1, Name = "Antarqtida", Description = "aq iyo batoni wyali romelmac wyali dalia", Price = 5.99, image_name = "antarqtida.jpg",Company_Id=1 },
                new Turebi { id = 2, Name = "Tbilisi", Description = "tbilo tibifli", Price = 15.99, image_name = "Tbilisi.jpg", Company_Id = 3 },
                new Turebi { id = 3, Name = "Parizi", Description = "parizelta dedaqali", Price = 6.99, image_name = "Parizi.jfif", Company_Id = 2 },
                new Turebi { id = 4, Name = "Los-Angeles, CA", Description = "მაგარიი პონტიიი", Price = 15555, image_name = "Los-AngelesCa.jfif", Company_Id = 4 },
                new Turebi { id = 5, Name = "Italy", Description = "მაგარიი პონტიიი", Price = 12341, image_name = "Italy.png", Company_Id = 1 },
                new Turebi { id = 6, Name = "Brazil", Description = "მაგარიი პონტიიი", Price = 15111, image_name = "Brazil.jfif", Company_Id = 2 },
                new Turebi { id = 7, Name = "Denmark", Description = "მაგარიი პონტიიი", Price = 19000, image_name = "Denmark.jfif", Company_Id = 4 },
                new Turebi { id = 8, Name = "Spain", Description = "მაგარიი პონტიიი", Price = 23000, image_name = "Spain.jfif", Company_Id = 3 }
                );
            modelBuilder.Entity<UserAndTurebiMap>().HasKey(u => new { u.Turebi_Id, u.User_Id });
            modelBuilder.Entity<Turebi>().HasOne(u => u.Company).WithMany(u => u.Turebi).HasForeignKey(u => u.Company_Id);
            modelBuilder.Entity<UserAndTurebiMap>().HasOne(u => u.turebi).WithMany(u => u.UserAndTurebiMapT).HasForeignKey(u => u.Turebi_Id);
            modelBuilder.Entity<UserAndTurebiMap>().HasOne(u => u.User).WithMany(u => u.UserAndTurebiMapU).HasForeignKey(u => u.User_Id);
        }
        

    }
}
