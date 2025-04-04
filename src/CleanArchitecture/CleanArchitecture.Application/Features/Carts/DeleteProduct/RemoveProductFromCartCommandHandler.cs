using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Carts.DeleteProduct
{
    public class RemoveProductFromCartCommandHandler : IRequestHandler<RemoveProductFromCartCommand, CartResponse?>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IProductRepository _productRepository;

        public RemoveProductFromCartCommandHandler(ICartRepository cartRepository, ICartProductRepository cartProductRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _cartProductRepository = cartProductRepository;
            _productRepository = productRepository;
        }
        
        public async Task<CartResponse?> Handle(RemoveProductFromCartCommand request, CancellationToken cancellationToken)
        {
            Cart? cart = await _cartRepository.GetByUserAsync(request.UserId);
            Product? product = await _productRepository.GetByIdAsync(request.ProductId);

            // Si el producto NO existe, se lanza una excepción
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            // Si el carrito NO existe, se lanza una excepción
            if (cart == null)
            {
                throw new Exception("Cart not found");
            }

            CartProduct? cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == request.ProductId);

            // Si el producto NO está en el carrito, se lanza una excepción
            if (cartProduct == null)
            {
                throw new Exception("Product not found in cart");
            }

            // Si la cantidad a eliminar es mayor o igual a la cantidad en el carrito, se elimina el producto del carrito
            if (request.Quantity >= cartProduct.Quantity)
            {
                await _cartProductRepository.DeleteProductFromCartAsync(cartProduct);
            }
            // Si la cantidad a eliminar es menor a la cantidad en el carrito, se actualiza la cantidad
            else
            {
                cartProduct.Quantity -= request.Quantity;
                await _cartProductRepository.UpdateAsync(cartProduct);
            }

            return cart.FromEntityToResponse();
        }
    }
}
