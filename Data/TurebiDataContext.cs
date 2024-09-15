using Microsoft.EntityFrameworkCore;
using TravelTo.Models;
namespace TravelTo.Data;

public class TurebiDataContext : DbContext
{
    public TurebiDataContext(DbContextOptions<TurebiDataContext> options) : base(options)
    {

    }
    public DbSet<Turebi2> turebi2s { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Turebi2>().HasData(
                new Turebi2 { TuriId = 1, Name = "Los-Angeles, CA", Description = "მაგარიი პონტიიი", Price = 15555, Image_name = "ee2aa1e4-37d6-41e1-a3b5-ee7d35f0202d.jfif" },
                new Turebi2 { TuriId = 2, Name = "Italy", Description = "მაგარიი პონტიიი", Price = 12341, Image_name = "bffe2b9f-956c-41a5-a72e-12b08c899a45.jfif" },
                new Turebi2 { TuriId = 4, Name = "Brazil", Description = "მაგარიი პონტიიი", Price = 15111, Image_name = "b373e51c-0ba1-4f3b-887d-3499cb200d3c.jpg" },
                new Turebi2 { TuriId = 5, Name = "Denmark", Description = "მაგარიი პონტიიი", Price = 19000, Image_name = "f521cee9-6c84-4a02-8f75-9800f0002a53.jfif" },
                new Turebi2 { TuriId = 6, Name = "Spain", Description = "მაგარიი პონტიიი", Price = 23000, Image_name = "6d4ea991-f9a5-4ec6-8550-0e4e02e5ab4c.jfif" }
                );
    }
}
