using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Storage
{
    public class GoodTripContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public GoodTripContext(DbContextOptions<GoodTripContext> options) : base(options)
        {
            
        }
    }
}
