using CleanArchitecture.Application.Features.Carts;
using CleanArchitecture.Application.Features.Orders;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappers
{
    public static class OrderMapper
    {
        public static OrderResponse FromEntityToResponse(this Order order)
        {
            OrderResponse response = new OrderResponse()
            {
                OrderProductsResponse = order.OrderProducts.Select(op => op.FromEntityToResponse())
            };

            return response;
        }
    }
}
