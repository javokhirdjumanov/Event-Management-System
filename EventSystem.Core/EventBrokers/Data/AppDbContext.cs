using EventSystem.Core.EventBrokers.Configuration;
using EventSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EventSystem.Core.EventBrokers.Data;
public class AppDBContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string configuring = "Server = (localdb)\\MSSQLLocalDB; " +
                      "Database = EventManagment;" +
                      "Trusted_Connection = True;";

        optionsBuilder.UseSqlServer(configuring);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rooms>()
            .HasMany(r => r.Orders)
            .WithOne(o => o.Room)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Rooms>()
            .HasMany(r => r.Events)
            .WithOne(e => e.Room)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Users>()
            .HasOne(u => u.Event)
            .WithOne(e => e.User)
            .HasForeignKey<Events>(e => e.User_id);

        modelBuilder.Entity<Users>()
            .HasOne(u => u.Order)
            .WithOne(o => o.User)
            .HasForeignKey<Orders>(o => o.User_id);

        modelBuilder.ApplyConfiguration(new UserConfigur());
        modelBuilder.ApplyConfiguration(new EventConfigur());
        modelBuilder.ApplyConfiguration(new RoomConfigur());
    }
    public DbSet<Users> Users { get; set; }
    public DbSet<Rooms> Rooms { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Events> Events { get; set; }
}
