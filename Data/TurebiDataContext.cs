using Microsoft.EntityFrameworkCore;
using TravelTo.Models;
namespace TravelTo.Data;

public class TurebiDataContext : DbContext
{
    public TurebiDataContext(DbContextOptions<TurebiDataContext> options) : base(options)
    {

    }
    public DbSet<Turebi2> turebi2s { get; set; }
}
