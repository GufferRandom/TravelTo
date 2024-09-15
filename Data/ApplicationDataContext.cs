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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Turebi>().HasData(
                new Turebi { id = 1, Name = "Antarqtida", Description = "aq iyo batoni wyali romelmac wyali dalia", Price = 5.99, image_name = "31394_1.jpg" },
                new Turebi { id = 2, Name = "Tbilisi", Description = "tbilo tibifli", Price = 15.99, image_name = "59564_1.jpg" },
                new Turebi { id = 3, Name = "Parizi", Description = "parizelta dedaqali", Price = 6.99, image_name = "59564_1.jpg" },
                new Turebi { id = 4, Name = "Los-Angeles, CA", Description = "მაგარიი პონტიიი", Price = 15555, image_name = "ee2aa1e4-37d6-41e1-a3b5-ee7d35f0202d.jfif" },
                new Turebi { id = 5, Name = "Italy", Description = "მაგარიი პონტიიი", Price = 12341, image_name = "bffe2b9f-956c-41a5-a72e-12b08c899a45.jfif" },
                new Turebi { id = 6, Name = "Brazil", Description = "მაგარიი პონტიიი", Price = 15111, image_name = "b373e51c-0ba1-4f3b-887d-3499cb200d3c.jpg" },
                new Turebi { id = 7, Name = "Denmark", Description = "მაგარიი პონტიიი", Price = 19000, image_name = "f521cee9-6c84-4a02-8f75-9800f0002a53.jfif" },
                new Turebi { id = 8, Name = "Spain", Description = "მაგარიი პონტიიი", Price = 23000, image_name = "6d4ea991-f9a5-4ec6-8550-0e4e02e5ab4c.jfif" }
                );


            modelBuilder.Entity<UserAndTurebiMap>().HasKey(u => new { u.Turebi_Id, u.User_Id });
            modelBuilder.Entity<Turebi>().HasOne(u => u.Company).WithMany(u => u.Turebi).HasForeignKey(u => u.Company_Id);
            modelBuilder.Entity<UserAndTurebiMap>().HasOne(u => u.turebi).WithMany(u => u.UserAndTurebiMapT).HasForeignKey(u => u.Turebi_Id);
            modelBuilder.Entity<UserAndTurebiMap>().HasOne(u => u.User).WithMany(u => u.UserAndTurebiMapU).HasForeignKey(u => u.User_Id);
        }
        

    }
}
