using Microsoft.EntityFrameworkCore;
using System;
using CarRentalManager.Model.DataManager.DataModel;

namespace CarRentalManager.Model.DataManager
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<TypeCar> TypeCars => Set<TypeCar>();
        public DbSet<Bank> Banks => Set<Bank>();

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=D2pmFe75;database=carrentaldata;",
                new MySqlServerVersion(new Version(8, 0, 33))
            );
        }
    }
}
