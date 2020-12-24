using CQRS.ProductAPI.Context;
using CQRS.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext ProductContext;

        public ProductRepository(ProductContext productContext)
        {
            ProductContext = productContext;
        }

        public void DeleteProduct(int productId)
        {
            var product = ProductContext.Products.Find(productId);
            ProductContext.Products.Remove(product);
            Save();
        }

        public Product GetProductById(int productId)
        {
            return ProductContext.Products.Find(productId);
        }

        public List<Product> GetAllProducts()
        { 
            return ProductContext.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            ProductContext.Add(product);
            Save();
        }

        public void Save()
        {
            ProductContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            ProductContext.Entry(product).State = EntityState.Modified;
            Save();
        }

    }
}