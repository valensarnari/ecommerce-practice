using CleanArchitecture.Application.Features.Carts;
using CleanArchitecture.Application.Features.Orders;
using CleanArchitecture.Application.Features.Products;
using CleanArchitecture.Application.Features.Products.Add;
using CleanArchitecture.Application.Features.Products.Update;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponse FromEntityToResponse(this Product product)
        {
            ProductResponse response = new ProductResponse()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category.Name
            };

            return response;
        }

        public static ProductForCartResponse FromEntityToResponseForCart(this Product product)
        {
            ProductForCartResponse response = new ProductForCartResponse()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category.Name
            };

            return response;
        }

        public static ProductForOrderResponse FromEntityToResponseForOrder(this Product product)
        {
            ProductForOrderResponse response = new ProductForOrderResponse()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category.Name
            };

            return response;
        }

        public static Product FromCommandToEntity(this AddProductCommand command)
        {
            Product product = new Product()
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                Stock = command.Stock,
                CategoryId = command.CategoryId
            };

            return product;
        }
    }
}
