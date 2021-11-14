﻿using InventoryZ.Core.Entities;
using InventoryZ.Core.Repositories;
using InventoryZ.Infrastructure.Persistence;
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

        public async Task CreateUser(User user)
        {
            try
            {
               await _context.User.AddAsync(user);
               await  _context.SaveChangesAsync();
            }catch(Exception e)
            {
                throw new Exception("Houve um erro ao criar o usuário. Erro: ", e);
            }
            
        }

        public List<Task<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
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
