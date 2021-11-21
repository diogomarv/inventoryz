using InventoryZ.Application.ViewModels;
using InventoryZ.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryZ.Application.Queries.GetAllProductsByUser
{
    public class GetAllProductsByUserQueryHandler : IRequestHandler<GetAllProductsByUserQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsByUserQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductsByUserQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsByUser(request.Id);

            var productsViewModel = products.Select(p => new ProductViewModel(p.Id, p.Name, p.Description, p.Price, p.Amount, p.SoldAmount, p.Date) ).ToList();

            return productsViewModel;
        }
    }
}
