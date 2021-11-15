using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Application.Commands.RemoveProduct
{
    public class RemoveProductCommand : IRequest<bool>
    {
        public int IdProduct { get; set; }
        public int IdUser { get; set; }
    }
}
