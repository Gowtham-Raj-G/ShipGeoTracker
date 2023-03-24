using Microsoft.EntityFrameworkCore;
using ShipGeoTracker.Database.Entities;

namespace ShipGeoTracker.Database
{
    public class ShipGeoTrackerContext : DbContext
    {
        public ShipGeoTrackerContext(DbContextOptions<ShipGeoTrackerContext> options) : base(options)
        {

        }

        public DbSet<Ship> Ships { get; set; }
        public DbSet<Port> Ports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ship>()
                    .Property(x => x.Id)
                    .ValueGeneratedNever();

            modelBuilder.Entity<Ship>()
                .Property(x => x.Name)
                .IsRequired().HasMaxLength(255);

            modelBuilder.Entity<Ship>()
                .Property(x => x.Latitude)
                .IsRequired();

            modelBuilder.Entity<Ship>()
                .Property(x => x.Velocity)
                .IsRequired();

            modelBuilder.Entity<Ship>()
                .Property(x => x.Longitude)
                .IsRequired();

            modelBuilder.Entity<Port>()
                    .Property(x => x.Id)
                    .ValueGeneratedNever();

            modelBuilder.Entity<Port>()
                .Property(x => x.Name)
                .IsRequired().HasMaxLength(255);

            modelBuilder.Entity<Port>()
                .Property(x => x.Latitude)
                .IsRequired();

            modelBuilder.Entity<Port>()
                .Property(x => x.Longitude)
                .IsRequired();
        }
    }
}
