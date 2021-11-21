using InventoryZ.Application.Commands.InsertProduct;
using InventoryZ.Application.Commands.RemoveProduct;
using InventoryZ.Application.Commands.UpdateProduct;
using InventoryZ.Application.Queries.GetAllProductsByUser;
using InventoryZ.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryZ.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertProduct([FromBody] InsertProductCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response)
                return BadRequest("Houve algum problema ao inserir o produto.");

            return Ok("Produto cadastrado com sucesso!");
        }

        [HttpGet("AllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] int idUser)
        {
            var p = new GetAllProductsByUserQuery();
            p.Id = idUser;

            var response = await _mediator.Send(p);

            if (!response.Any())
                return BadRequest("Não há produtos cadastrados.");

            return Ok(response);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> RemoveById([FromQuery] int idProduct, [FromHeader] int idUser)
        {
            var command = new RemoveProductCommand();
            command.IdProduct = idProduct;
            command.IdUser = idUser;

            var response = await _mediator.Send(command);

            if (!response)
                return BadRequest("Falha ao remover produto.");

            return Ok("Produto removido com sucesso!");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProjectCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response)
                return BadRequest("Houve um problema ao editar o produto. Tente novamente.");

            return Ok("Produto editado com sucesso!");
        }

    }
}
