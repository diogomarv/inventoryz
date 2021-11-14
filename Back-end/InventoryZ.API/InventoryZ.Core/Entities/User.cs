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
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; private set; } = true;
        public string ProfilePhoto { get; private set; }
        public List<Product> Product { get; private set; }


    }
}
