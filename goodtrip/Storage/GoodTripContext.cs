using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Route = goodtrip.Storage.Entity.Route;


namespace goodtrip.Storage
{
    public class GoodTripContext : IdentityDbContext<User, UserRole, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperatorProfile> UserOperatorProfiles { get; set; }
        public DbSet<UserCustomerProfile> UserCustomerProfiles { get; set; }
        public DbSet<Tour> Tours { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<ImageExcurtion> ImageExcurtion { get; set; }

        public DbSet<ImageHotel> ImageHotel { get; set; }

        public DbSet<Excurtion> Excurtions { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Route> Routes { get; set; }
        public DbSet<ImageExcurtion> ImagesExcurtion { get; set; }
        public DbSet<ImageHotel> ImagesHotel { get; set; }

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
/*            builder.Entity<Tour>()
                .HasOne(t => t.FlightBack)
                .WithOne(f => f.Tour)
                .HasForeignKey<Flight>(c => c.TourID);*/
        }
    }
}
