using Microsoft.EntityFrameworkCore;
using SmartHotel.Domain.Entities;
using System;
using System.Linq;

namespace SmartHotel.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Guest> Guest { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Pendency> Pendency { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*set default string length 100 and column type varchar*/

            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.GetColumnType() == null
                ))
            {
                if (property.GetColumnType() == null)
                    property.SetColumnType("varchar(100)");
            }

            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                if (property.GetColumnType() == null)
                    property.SetColumnType("decimal(13,2)");
            }
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegistrationDate").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}