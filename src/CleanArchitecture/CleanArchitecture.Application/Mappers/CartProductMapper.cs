using CleanArchitecture.Application.Features.Carts;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappers
{
    public static class CartProductMapper
    {
        public static CartProductResponse FromEntityToResponse(this CartProduct cartProduct)
        {
            CartProductResponse response = new CartProductResponse()
            {
                Quantity = cartProduct.Quantity,
                ProductForCartResponse = cartProduct.Product.FromEntityToResponseForCart()
            };

            return response;
        }
    }
}
