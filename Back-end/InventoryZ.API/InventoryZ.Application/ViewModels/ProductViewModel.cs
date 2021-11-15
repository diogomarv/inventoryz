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

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }
        public int SoldAmount { get; private set; }
        public DateTime Date { get; private set; }
    }
}
