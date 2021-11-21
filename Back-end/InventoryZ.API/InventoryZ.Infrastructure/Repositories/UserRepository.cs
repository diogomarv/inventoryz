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
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;
        private string connectionString;
        public UserRepository(DataBaseContext context, IConfiguration configuration)
        {
            _context = context;
            connectionString = configuration.GetConnectionString("DataBaseInventoryZ");
        }

        public async Task<bool> RegisterUser(User user)
        {

            try
            {

                var emailAlreadyExists = await GetUserByEmail(user.Email) != null ? true : false;

                if (emailAlreadyExists)
                {
                    return false;
                }
                
                await _context.User.AddAsync(user);
                await  _context.SaveChangesAsync();

                return true;

            }catch(Exception e)
            {
                throw new Exception("Houve um erro ao criar o usuário. Erro: ", e);
            }
            
        }

        public List<Task<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmail(string email)
        {

            //string script = @"SELECT 
            //                   [Id]
            //                  ,[Name]
            //                  ,[Email]
            //                  ,[Password]
            //                  ,[ProfilePhoto]
            //                FROM[InventoryZ].[dbo].[User]
            //                WHERE Email = '@email' ";

            throw new NotImplementedException();

        }

        public async Task<User> GetUserById(int id)
        {
                try
                {
                    var user = await _context.User.Where(u => u.Id == id).FirstOrDefaultAsync();
                    
                    return user;

                }catch(Exception e)
                {
                    throw new Exception("Ocorreu um erro ao buscar o usuário. Erro: ", e);
                }
        }

        public Task<User> GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            var user = await _context.User.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

            return user;
        }
    }
}
