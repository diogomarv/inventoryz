using InventoryZ.Core.Entities;
using InventoryZ.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryZ.Application.Commands.InsertProduct
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public InsertProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product(request.Name, request.Description, request.Price, request.Amount, request.SoldAmount, DateTime.Now, request.IdUser);

            return await _productRepository.InsertProduct(product);
        }
    }
}
