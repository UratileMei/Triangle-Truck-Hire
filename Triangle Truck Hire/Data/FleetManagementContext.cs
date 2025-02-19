using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Triangle_Truck_Hire.Model;

namespace Triangle_Truck_Hire.Data
{
    public class FleetManagementContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Load> Loads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FleetManagement.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().ToTable("Drivers");
            modelBuilder.Entity<Load>().ToTable("Loads");
        }
    }
}
