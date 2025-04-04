using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Carts.AddProduct
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, CartResponse?>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IProductRepository _productRepository;

        public AddProductToCartCommandHandler(ICartRepository cartRepository, ICartProductRepository cartProductRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _cartProductRepository = cartProductRepository;
            _productRepository = productRepository;
        }

        public async Task<CartResponse?> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            Cart? cart = await _cartRepository.GetByUserAsync(request.UserId);
            Product? product = await _productRepository.GetByIdAsync(request.ProductId);

            // Si el producto NO existe, se lanza una excepción
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            // Si el carrito NO existe, se crea un carrito nuevo
            if (cart == null)
            {
                cart = await _cartRepository.AddAsync(new Cart { UserId = request.UserId });
            }

            CartProduct? cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == request.ProductId);

            // Si el producto NO está en el carrito, se agrega el producto con la cantidad solicitada
            if (cartProduct == null)
            {
                CartProduct newCartProduct = new CartProduct
                {
                    CartId = cart.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };

                await _cartProductRepository.AddAsync(newCartProduct);
            }

            // Si el producto YA está en el carrito, se actualiza la cantidad
            else
            {
                cartProduct.Quantity += request.Quantity;
                await _cartProductRepository.UpdateAsync(cartProduct);
            }

            return cart.FromEntityToResponse();
        }
    }
}
