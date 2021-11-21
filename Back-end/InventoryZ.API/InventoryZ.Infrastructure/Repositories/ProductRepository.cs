using Dapper;
using InventoryZ.Core.Entities;
using InventoryZ.Core.Repositories;
using InventoryZ.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private string connectionString;
        public ProductRepository(DataBaseContext context, IConfiguration configuration)
        {
            _context = context;
            connectionString = configuration.GetConnectionString("DataBaseInventoryZ");
        }

        public async Task<bool> EditProduct(Product product)
        {

            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    string script = @"  UPDATE Product
                                        SET 
                                         Name = @name,
                                         Description = @description,
                                         Price = @price,
                                         Date = @date,
                                         Amount = @amount
                                        WHERE Id = @id;";

                    await sqlConnection.QueryAsync<Product>(script, new { id = product.Id, name = product.Name, description = product.Description, price = product.Price, date = DateTime.Now, amount = product.Amount });

                    return true;
               
                }
            }catch(Exception e)
            {
                return false;
                throw new Exception("Ocorreu um erro ao editar o produto. Erro: ", e);
            }

        }

        public async Task<List<Product>> GetAllProductsByUser(int id)
        {

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM [InventoryZ].dbo.[Product]
                               WHERE IdUser = @id;";

                var products = sqlConnection.Query<Product>(sql, new { id }).ToList();

                return products;
            }
        }

        public Task<Product> GetProductByEmailUser(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByUserIdAsync(int idProduct, int idUser)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var script = @"SELECT * FROM [InventoryZ].dbo.[Product]
                               WHERE Id = @idProduct AND IdUser = @idUser;";

                var product = await sqlConnection.QueryAsync<Product>(script, new { idProduct, idUser });
                
                return product.FirstOrDefault();
            }
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

        public async Task<bool> RemoveProductAsync(int idProduct, int idUser)
        {
            try
            {
                // Check if the product belongs to the user
                var product = await GetProductByUserIdAsync(idProduct, idUser);

                if (product == null)
                    return false;
                
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }catch(Exception e)
            {
                throw new Exception("Houve um erro ao deletar o produto. Erro: ", e);
            }
        }
    }
}
