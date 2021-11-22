using InventoryZ.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Application.Commands.InsertProduct
{
    public class InsertProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int SoldAmount { get; set; } = 0;
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        /// <summary>
        /// Email - User email
        /// </summary>
        public User User { get; set; }
    }
}
