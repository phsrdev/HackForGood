using Microsoft.EntityFrameworkCore;

namespace MiPark
{

    public class DataBase : DbContext
    { 
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserCar> UserCars { get; set; }

        // Connect to DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection to DataBase censored for confidential porpuses
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FlexParkDB;Username=flexparkadm;Password=flexpark123");
        }

        // Put Data on respective tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Car>().ToTable("cars");
            modelBuilder.Entity<UserCar>().ToTable("usercars");
        }
    }
}
