using InventoryZ.Application.Commands.LoginUser;
using InventoryZ.Application.Commands.RegisterUser;
using InventoryZ.Application.Queries.GetUserInformations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryZ.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response)
                return BadRequest("Já existe um usuário cadastrado com este e-mail.");

            return Ok("Usuario cadastrado com sucesso!");
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
                return BadRequest("Login e/ou senha inválidos.");

            return Ok(response);
        }

        [HttpGet("userInformation")]
        public async Task<IActionResult> GetUserInformations([FromQuery] int userId)
        {
            var user = new GetUserInformationsQuery(userId);

            var response = await _mediator.Send(user);

            return Ok(response);
        }
    }
}
