using CleanArchitecture.Application.Features.Orders;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappers
{
    public static class OrderProductMapper
    {
        public static OrderProductResponse FromEntityToResponse(this OrderProduct orderProduct)
        {
            OrderProductResponse response = new OrderProductResponse()
            {
                Quantity = orderProduct.Quantity,
                ProductForOrderResponse = orderProduct.Product.FromEntityToResponseForOrder()
            };

            return response;
        }
    }
}
