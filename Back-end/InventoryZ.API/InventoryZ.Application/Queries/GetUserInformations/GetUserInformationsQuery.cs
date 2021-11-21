using InventoryZ.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Application.Queries.GetUserInformations
{
    public class GetUserInformationsQuery : IRequest<UserInformationsViewModel>
    {
        public int Id { get; set; }

        public GetUserInformationsQuery(int id)
        {
            Id = id;
        }
    }
}
