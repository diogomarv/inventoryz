﻿using InventoryZ.Application.Commands.InsertProduct;
using InventoryZ.Application.Commands.RemoveProduct;
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

        [HttpGet("GetAllProducts/")]
        public Task<List<ProductViewModel>> GetAllProducts([FromHeader] string email)
        {
            var p = new GetAllProductsByUserQuery();
            p.Email = email;

            var products = _mediator.Send(p);

            return products;
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

    }
}
