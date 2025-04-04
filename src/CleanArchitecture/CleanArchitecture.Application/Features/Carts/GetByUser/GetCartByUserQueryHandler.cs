using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Carts.GetByUser
{
    public class GetCartByUserQueryHandler : IRequestHandler<GetCartByUserQuery, CartResponse?>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartByUserQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartResponse?> Handle(GetCartByUserQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByUserAsync(request.UserId);

            if (cart == null)
            {
                return null;
            }

            return cart.FromEntityToResponse();
        }
    }
}
