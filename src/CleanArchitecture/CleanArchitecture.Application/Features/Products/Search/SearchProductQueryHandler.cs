using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.Search
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, IEnumerable<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public SearchProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponse>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(request.Name))
            {
                products = products.Where(p => p.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                products = products.Where(p => p.Description.Contains(request.Description, StringComparison.OrdinalIgnoreCase));
            }

            if (request.CategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == request.CategoryId.Value);
            }

            return products.Select(p => p.FromEntityToResponse());
        }
    }
}
