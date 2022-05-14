using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Storage
{
    public class GoodTripContext : IdentityDbContext<User, UserRole, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperatorProfile> UserOperatorProfiles { get; set; }
        public DbSet<UserCustomerProfile> UserCustomerProfiles { get; set; }
        public DbSet<Tour> Tours { get; set; }

        public DbSet<Transportation> Transportations { get; set; }

        public GoodTripContext(DbContextOptions<GoodTripContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

        }
    }
}
