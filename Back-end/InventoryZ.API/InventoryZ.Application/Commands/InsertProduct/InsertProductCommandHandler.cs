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

        public Task<bool> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
