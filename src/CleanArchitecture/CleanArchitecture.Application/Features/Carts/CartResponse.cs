using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Carts
{
    public class CartResponse
    {
        public IEnumerable<CartProductResponse> CartProductsResponse { get; set; }
    }
}
