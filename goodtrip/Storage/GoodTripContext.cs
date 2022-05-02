using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Storage
{
    public class GoodTripContext : IdentityDbContext<User, UserRole, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
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
            //builder.Entity<IdentityUserLogin<string>>().HasNoKey();
        }
    }
}
