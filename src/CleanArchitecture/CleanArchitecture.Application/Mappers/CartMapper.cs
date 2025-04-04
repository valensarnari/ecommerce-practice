using CleanArchitecture.Application.Features.Carts;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappers
{
    public static class CartMapper
    {
        public static CartResponse FromEntityToResponse(this Cart cart)
        {
            CartResponse response = new CartResponse()
            {
                CartProductsResponse = cart.CartProducts.Select(cp => cp.FromEntityToResponse())
            };

            return response;
        }
    }
}
