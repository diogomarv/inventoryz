using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Core.Services
{
    public interface IAuthService
    {
        string GenerateSha256Hash(string password);
    }
}
