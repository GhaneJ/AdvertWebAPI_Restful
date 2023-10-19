namespace AdvertWebAPI_Restful.Data;

using AdvertWebAPI_Restful.Model;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Advert> Adverts { get; set; }
}
