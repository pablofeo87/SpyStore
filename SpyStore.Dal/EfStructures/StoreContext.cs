using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SpyStore.Models.Entities;
using SpyStore.Models.Entities.Base;

namespace SpyStore.Dal.EfStructures
{
    public class StoreContext : DbContext
    {
        public int CustomerId { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress).HasName("IX_Customers").IsUnique();
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.ShipDate).HasColumnType("datetime").HasDefaultValueSql("getdate()");
            });
            modelBuilder.Entity<Order>().HasQueryFilter(x => x.CustomerId == CustomerId);
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.UnitCost).HasColumnType("money");
            });
        }
    }
}
