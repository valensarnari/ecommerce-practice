using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.Search
{
    public record SearchProductQuery(string? Name, string? Description, int? CategoryId) : IRequest<IEnumerable<ProductResponse>>;
}
