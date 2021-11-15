using InventoryZ.Application.Commands.LoginUser;
using InventoryZ.Application.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryZ.API.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response)
                return BadRequest("Já existe um usuário cadastrado com este e-mail.");

            return Ok("Usuario cadastrado com sucesso!");
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            
        }
    }
}
