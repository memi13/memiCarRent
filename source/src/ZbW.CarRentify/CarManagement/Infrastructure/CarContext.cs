using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Infrastructure
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\v11.0;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var carEntity = modelBuilder.Entity<Car>();
            carEntity.HasKey(x => x.Id);
            carEntity.HasOne(x => x.Model);
            carEntity.UsePropertyAccessMode(PropertyAccessMode.Field);

            var brandEntity = modelBuilder.Entity<Brand>();
            brandEntity.HasMany(x => x.Models);

            base.OnModelCreating(modelBuilder);
        }
    }
}
