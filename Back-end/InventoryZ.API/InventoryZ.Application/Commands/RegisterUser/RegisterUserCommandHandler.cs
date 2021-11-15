using InventoryZ.Core.Repositories;
using InventoryZ.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryZ.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {

        private readonly IUserRepository _userRepository;
        private readonly IAuthService _auth;

        public RegisterUserCommandHandler(IUserRepository userRepository, IAuthService auth)
        {
            _userRepository = userRepository;
            _auth = auth;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var hashPassword = _auth.GenerateSha256Hash(request.Password);

            return await _userRepository.RegisterUser(new Core.Entities.User() { Name = request.Name, Email = request.Email, Password = hashPassword });
            
        }
    }
}
