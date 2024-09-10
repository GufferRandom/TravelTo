using Microsoft.EntityFrameworkCore;
using TravelTo.Models;

namespace TravelTo.Data
{
    public class ApplicationDataContext:DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Turebi> Turebis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<Company>().HasData(
       new Company { Company_Id = 1, Name = "BOG" },
       new Company { Company_Id = 2, Name = "TBC" }
   );

            modelBuilder.Entity<Turebi>().HasData(
                new Turebi { id = 1,Company_Id=1, Name = "Antarqtida", Description = "aq iyo batoni wyali romelmac wyali dalia", Price = 5.99, image_name = "31394_1.jpg" },
                new Turebi { id = 2, Company_Id=2,Name = "Tbilisi", Description = "tbilo tibifli", Price = 15.99, image_name = "59564_1.jpg" },
                new Turebi { id = 3, Company_Id = 2, Name = "Parizi", Description = "parizelta dedaqali", Price = 6.99, image_name = "59564_1.jpg" }
                );
          
            modelBuilder.Entity<Turebi>().HasOne(u=>u.Company).WithMany(u=>u.Turebi).HasForeignKey(u=>u.Company_Id).IsRequired();
        }
    }
}
