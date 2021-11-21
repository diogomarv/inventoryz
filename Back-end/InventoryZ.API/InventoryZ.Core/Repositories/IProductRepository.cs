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
        Task<bool> RemoveProductAsync(int idProduct, int idUser);
        Task<Product> GetProductByEmailUser(string email);
        Task<Product> GetProductByUserIdAsync(int idProduct, int idUser);
        Task<List<Product>> GetAllProductsByUser(int id);
        Task<bool> EditProduct(Product product);
        
    }
}
