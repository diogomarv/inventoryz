using InventoryZ.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryZ.Application.Commands.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public RemoveProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {

            return await _productRepository.RemoveProductAsync(request.IdProduct, request.IdUser);

        }
    }
}
