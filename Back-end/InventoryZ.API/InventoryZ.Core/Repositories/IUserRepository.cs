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
        Task<bool> RegisterUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserByLogin(string login);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        List<Task<User>> GetAllUsers();
    }
}
