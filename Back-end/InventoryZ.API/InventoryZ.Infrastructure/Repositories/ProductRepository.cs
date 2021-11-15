using InventoryZ.Core.Entities;
using InventoryZ.Core.Repositories;
using InventoryZ.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataBaseContext _context;
        public ProductRepository(DataBaseContext context)
        {
            _context = context;
        }

        public Task<List<Product>> GetAllProductsByUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByEmailUser(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertProduct(Product product)
        {

            User user = await _context.User.Where(u => u.Email == product.User.Email).FirstOrDefaultAsync();

            if (user == null)
                return false;

            try
            {
                product.User = user;
                await _context.Product.AddAsync(product);
                await _context.SaveChangesAsync();

                return true;

            }catch(Exception e)
            {
                throw new Exception("Houve um erro ao inserir o produto. Erro: ", e);
            }
        }
    }
}
