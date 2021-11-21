using InventoryZ.Application.ViewModes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
