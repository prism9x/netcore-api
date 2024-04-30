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

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category) // chỉ ra một product có 1 category
                        .WithMany(c => c.Products) // chỉ ra một category thì có nhiều product
                        .HasForeignKey(p => p.CategoryId); // chỉ ra khóa ngoại của chúng là CategoryId trong bảng Products
        }
    }
}