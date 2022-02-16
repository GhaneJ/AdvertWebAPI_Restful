using AdvertWebAPI_Restful.Model;
using Microsoft.EntityFrameworkCore;

namespace AdvertWebAPI_Restful.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Advert> Adverts { get; set; }
    }
}
