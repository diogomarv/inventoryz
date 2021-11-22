using InventoryZ.Application.ViewModels;
using InventoryZ.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryZ.Application.Queries.GetProductsSoldByUser
{
    public class GetProductsSoldCommandHandler : IRequestHandler<GetProductsSoldCommand, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsSoldCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModel>> Handle(GetProductsSoldCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsSoldByUser(request.IdUser);

            var productsViewModel = products.Select(p => new ProductViewModel() { Id = p.Id, Name = p.Name, Description = p.Description, Amount = p.Amount, Date = p.Date, Price = p.Price, SoldAmount = p.SoldAmount }).ToList();

            return productsViewModel;

        }
    }
}
