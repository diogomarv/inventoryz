using InventoryZ.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Application.Queries.GetProductsSoldByUser
{
    public class GetProductsSoldCommand : IRequest<List<ProductViewModel>>
    {
        public int IdUser { get; set; }
    }
}
