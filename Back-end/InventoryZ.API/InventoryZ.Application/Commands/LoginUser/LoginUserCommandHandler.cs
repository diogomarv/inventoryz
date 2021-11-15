using InventoryZ.Application.ViewModes;
using InventoryZ.Core.Repositories;
using InventoryZ.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryZ.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            // turn the password into hash
            var hashPassword = _authService.GenerateSha256Hash(request.Password);

            // check if email and passwords matches
            var emailAndPasswordMatches = await _userRepository.GetUserByEmailAndPassword(request.Email, hashPassword) != null ? true : false;

            // if matches, generate the token
            if (!emailAndPasswordMatches)
                return null;

            string token = _authService.GenerateJwtToken(request.Email);

            return new LoginUserViewModel { Email = request.Email, Token = token };

            

        }
    }
}
