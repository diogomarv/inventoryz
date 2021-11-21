using InventoryZ.Application.ViewModels;
using InventoryZ.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryZ.Application.Queries.GetUserInformations
{
    public class GetUserInformationsQueryHandler : IRequestHandler<GetUserInformationsQuery, UserInformationsViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserInformationsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserInformationsViewModel> Handle(GetUserInformationsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);

            var userViewModel = new UserInformationsViewModel() { Id = user.Id, Name = user.Name, Email = user.Email, ProfilePhoto = user.ProfilePhoto };

            return userViewModel;
        }
    }
}
