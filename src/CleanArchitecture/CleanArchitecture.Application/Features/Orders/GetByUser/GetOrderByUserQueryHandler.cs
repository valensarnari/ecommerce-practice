using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Orders.GetByUser
{
    public class GetOrderByUserQueryHandler : IRequestHandler<GetOrderByUserQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByUserQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrderByUserQuery request, CancellationToken cancellationToken)
            => (await _orderRepository.GetByUserAsync(request.UserId)).Select(o => o.FromEntityToResponse());
    }
}
