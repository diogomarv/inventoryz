using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Core.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public string ProfilePhoto { get; private set; }
        public List<Product> Product { get; private set; }


    }
}
