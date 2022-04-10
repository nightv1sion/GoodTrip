using goodtrip.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Storage
{
    public class GoodTripContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public GoodTripContext(DbContextOptions<GoodTripContext> options) : base(options)
        {
            
        }
    }
}
