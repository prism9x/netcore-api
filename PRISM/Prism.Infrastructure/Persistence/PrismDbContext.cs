using Microsoft.EntityFrameworkCore;
using Prism.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Infrastructure.Persistence
{
    public class PrismDbContext : DbContext
    {
        public PrismDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region -- Product Table --

            modelBuilder.Entity<Product>()
                        .HasKey(p => p.Id); // Khóa chính

            modelBuilder.Entity<Product>()
                        .Property(p => p.Id)
                        .ValueGeneratedOnAdd();  // Khóa tự tăng

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId); // Đặt khóa ngoại của Product là CategoryId

            #endregion -- Product Table --

            #region -- Category Table --
            modelBuilder.Entity<Category>()
                        .HasKey(c => c.Id); // Khóa chính

            modelBuilder.Entity<Category>()
                        .Property(p => p.Id)
                        .ValueGeneratedOnAdd();  // Khóa tự tăng

            #endregion -- Category Table --

        }
    }
}