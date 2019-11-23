using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
        {

        }

        public DbSet<Category> tblcategories { get; set; }
        public DbSet<Product> tblproducts { get; set; }
        public DbSet<Vendor> tblvendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(x =>
            {
                x.HasKey(z => z.ID);
                x.Property(z => z.Name).IsRequired();
            });

            modelBuilder.Entity<Vendor>(x =>
            {
                x.HasKey(z => z.ID);
                x.Property(z => z.CompanyName).IsRequired();
            });

            modelBuilder.Entity<Product>(x =>
            {
                x.HasKey(z => z.ID);
                x.Property(z => z.Name).IsRequired();
                x.Property(z => z.Price).IsRequired();
                x.Property(z => z.Quantity).IsRequired();
                x.Property(z => z.Description).IsRequired();
                x.HasOne(z => z.Vendor).WithMany(z => z.products).HasForeignKey(z => z.VendorID);
                x.HasOne(z => z.Category).WithMany(z => z.products).HasForeignKey(z => z.CategoryID);
            });
        }
    }
}
