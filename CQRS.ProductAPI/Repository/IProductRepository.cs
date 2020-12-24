using CQRS.ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int ProductId);
        void AddProduct(Product Product);
        void DeleteProduct(int ProductId);
        void UpdateProduct(Product Product);
        void Save();
    }
}
