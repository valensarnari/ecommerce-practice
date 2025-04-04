using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Orders.GetByUser
{
    public record GetOrderByUserQuery(int UserId) : IRequest<IEnumerable<OrderResponse>>;
}
