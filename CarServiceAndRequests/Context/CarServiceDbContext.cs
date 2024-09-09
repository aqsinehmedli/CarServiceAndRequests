using CarServiceAndRequests.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarServiceAndRequests.Context;

public class CarServiceDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarService> CarServices { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-0MV3INK;Initial Catalog = CarService;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Car>()
            .HasMany(c => c.CarServices)
            .WithMany(cs => cs.Cars)
          .UsingEntity<Dictionary<string, object>>(
             "CSService",
             j => j.HasOne<CarService>().WithMany().HasForeignKey("CarServiceId"),
             j => j.HasOne<Car>().WithMany().HasForeignKey("CarId")
             );
                
    }
}


