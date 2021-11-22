using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Application.ViewModels
{
    public class ProductViewModel
    {

        public ProductViewModel()
        {

        }

        public ProductViewModel(int id, string name, string description, decimal price, int amount, int soldAmount, DateTime date)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
            SoldAmount = soldAmount;
            Date = date;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int SoldAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
