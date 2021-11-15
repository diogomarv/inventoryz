using InventoryZ.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        public string GenerateSha256Hash(string password)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                // ComputeHash ---> turn the string password into bytes
                byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert bytes into string
                StringBuilder builder = new StringBuilder();

                for(var i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // x2 == convert to hexadecimal notation
                }

                return builder.ToString();
            }
        }
    }
}
