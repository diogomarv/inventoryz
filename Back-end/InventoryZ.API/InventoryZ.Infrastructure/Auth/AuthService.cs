using InventoryZ.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string email)
        {
            string issuer = _configuration["Jwt:Issuer"];
            string audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];

            // convert security key into bytes
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Tells who the token belongs
            var claim = new List<Claim>
            {
                new Claim("email", email)
            };

            // generates token
            var token = new JwtSecurityToken
                (
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials,
                claims: claim
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }

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
