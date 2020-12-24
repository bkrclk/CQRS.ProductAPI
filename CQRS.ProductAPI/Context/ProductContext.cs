using CQRS.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
          new Category
          {
              Id = 1,
              Name = "Electronics",
              Description = "Electronic Items",
          },
          new Category
          {
              Id = 2,
              Name = "Decoration",
              Description = "Decoration Items",
          },
          new Category
          {
              Id = 3,
              Name = "Greengrocer",
              Description = "Greengrocer Items",
          },
          new Category
          {
              Id = 4,
              Name = "Delicatessen",
              Description = "Delicatessen Items",
          });
        }
    }
}
