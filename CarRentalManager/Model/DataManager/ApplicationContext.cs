using Microsoft.EntityFrameworkCore;
using System;
using CarRentalManager.Model.DataManager.DataModel;

namespace CarRentalManager.Model.DataManager
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

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
