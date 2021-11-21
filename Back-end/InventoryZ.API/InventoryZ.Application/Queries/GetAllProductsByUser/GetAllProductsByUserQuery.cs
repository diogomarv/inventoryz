using InventoryZ.Application.ViewModels;
using InventoryZ.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Application.Queries.GetAllProductsByUser
{
    public class GetAllProductsByUserQuery : IRequest<List<ProductViewModel>>
    {
        public int Id { get; set; }
    }
}
