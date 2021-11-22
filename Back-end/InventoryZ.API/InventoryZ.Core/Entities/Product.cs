using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Core.Entities
{
    public class Product
    {
        public Product()
        {
                
        }
        public Product(string name, string description, decimal price, int amount, int soldAmount, DateTime date, int idUser)
        {
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
            SoldAmount = soldAmount;
            Date = date;
            IdUser = idUser;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int SoldAmount { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
