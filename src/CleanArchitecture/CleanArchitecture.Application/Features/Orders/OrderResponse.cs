using CleanArchitecture.Application.Features.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Orders
{
    public class OrderResponse
    {
        public IEnumerable<OrderProductResponse> OrderProductsResponse { get; set; }
    }
}
