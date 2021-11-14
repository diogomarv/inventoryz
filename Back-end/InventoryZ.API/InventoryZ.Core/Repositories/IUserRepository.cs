using InventoryZ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserByLogin(string login);
        Task<User> GetUserByEmail(string email);
        List<Task<User>> GetAllUsers();
    }
}
