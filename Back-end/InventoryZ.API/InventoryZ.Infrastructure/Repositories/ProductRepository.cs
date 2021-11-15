﻿using Dapper;
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

        public async Task<List<Product>> GetAllProductsByUser(string email)
        {
            var user = await _context.User.Where(u => u.Email == email).FirstOrDefaultAsync();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM [InventoryZ].dbo.[Product]
                               WHERE IdUser = @id;";

                var products = sqlConnection.Query<Product>(sql, new { id = user.Id }).ToList();

                return products;
            }
        }

        public Task<Product> GetProductByEmailUser(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByUserIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var script = @"SELECT * FROM [InventoryZ].dbo.[Product]
                               WHERE IdUser = @id;";

                var product = await sqlConnection.QueryAsync<Product>(script, new { id });
                
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

        public Task<bool> RemoveProductAsync(int idProduct, int idUser)
        {
            throw new NotImplementedException();
        }
    }
}
