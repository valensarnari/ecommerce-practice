using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.GetById
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductResponse?>;
}
