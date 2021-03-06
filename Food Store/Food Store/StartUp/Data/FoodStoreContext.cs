﻿using Microsoft.EntityFrameworkCore;
using StartUp.Data.Models;

namespace StartUp.Data
{

   public class FoodStoreContext : DbContext
    {
        public FoodStoreContext()
        {
            
        }

        public FoodStoreContext(DbContextOptions options) :base(options)
        {
            
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
   


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().
                HasOne(s => s.Store).
                WithMany(b => b.Employees)
                .HasForeignKey(p => p.StoreId)
                .HasConstraintName("ForeignKey_Employee_Store");

            modelBuilder.Entity<Product>().
                HasOne(s => s.Store).
                WithMany(b => b.Products)
                .HasForeignKey(p => p.ProductStoreId)
                .HasConstraintName("ForeignKey_Product_Store");

            base.OnModelCreating(modelBuilder);  
        }
    }
}
