using InventoryZ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Core.Repositories
{
    public interface IProductRepository
    {
        Task<bool> InsertProduct(Product product);
        Task<Product> GetProductByEmailUser(string email);
        Task<List<Product>> GetAllProductsByUser(string email);
    }
}
