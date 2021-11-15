﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Core.Entities
{
    public class Product
    {
        public Product(string name, string description, decimal price, int amount, int soldAmount, User user)
        {
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
            SoldAmount = soldAmount;
            Date = DateTime.Now;
            User = user;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }
        public int SoldAmount { get; private set; }
        public DateTime Date { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; set; }
    }
}
