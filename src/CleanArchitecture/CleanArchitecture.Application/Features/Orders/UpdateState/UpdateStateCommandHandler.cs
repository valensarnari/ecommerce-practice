using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Orders.UpdateState
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateStateCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            if (order == null)
            {
                return false;
            }

            if (Enum.TryParse<State>(request.State, true, out State enumValue))
            {
                order.State = enumValue;
                await _orderRepository.UpdateAsync(order);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
