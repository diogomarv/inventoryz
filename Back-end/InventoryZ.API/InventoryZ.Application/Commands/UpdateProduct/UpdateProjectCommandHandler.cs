using InventoryZ.Core.Entities;
using InventoryZ.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryZ.Application.Commands.UpdateProduct
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProjectCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Id = request.Id;
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Amount = request.Amount;

            if (await _productRepository.EditProduct(product))
                return true;

            return false;

            
            
        }
    }
}
