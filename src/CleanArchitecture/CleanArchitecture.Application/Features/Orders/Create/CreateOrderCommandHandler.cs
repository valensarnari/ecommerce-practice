using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Orders.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ICartRepository cartRepository, IOrderProductRepository orderProductRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _orderProductRepository = orderProductRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByUserAsync(request.UserId);

            if (cart == null)
            {
                throw new Exception("Cart not found.");
            }

            // Reviso si hay stock de los productos en el carrito
            foreach (var cartProduct in cart.CartProducts)
            {
                if (cartProduct.Quantity > cartProduct.Product.Stock)
                {
                    throw new Exception($"Not enough stock for product {cartProduct.Product.Name}.");
                }
            }

            // Primero creo la orden
            var order = new Order
            {
                UserId = request.UserId
            };
            var createdOrder = await _orderRepository.AddAsync(order);

            // Despues agrego los productos a la orden
            foreach (var cartProduct in cart.CartProducts)
            {
                var orderProduct = new OrderProduct
                {
                    OrderId = createdOrder.Id,
                    ProductId = cartProduct.ProductId,
                    Quantity = cartProduct.Quantity
                };
                await _orderProductRepository.AddAsync(orderProduct);

                // Actualizo el stock del producto
                cartProduct.Product.Stock -= cartProduct.Quantity;
                await _productRepository.UpdateAsync(cartProduct.Product);
            }
            
            // Finalmente elimino el carrito
            await _cartRepository.DeleteAsync(cart.Id);

            return createdOrder.FromEntityToResponse();
        }
    }
}
