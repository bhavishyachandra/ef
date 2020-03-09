using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BhavisProducts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerProduct> CustomerProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerProduct>()
                .HasKey(cp => new { cp.CustomerId, cp.ProductId });

            modelBuilder.Entity<CustomerProduct>()
                .HasOne(c => c.Customer)
                .WithMany(p => p.CustomerProducts)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<CustomerProduct>()
                .HasOne(p => p.Product)
                .WithMany(c => c.CustomerProducts)
                .HasForeignKey(p => p.ProductId);
        }

    }
}
