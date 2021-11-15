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
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;
        public UserRepository(DataBaseContext context)
        {
            _context = context;
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
            return await _context.User.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
