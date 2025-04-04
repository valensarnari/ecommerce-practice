using CleanArchitecture.Application.Features.Products.Add;
using CleanArchitecture.Application.Features.Products.Delete;
using CleanArchitecture.Application.Features.Products.GetById;
using CleanArchitecture.Application.Features.Products.Search;
using CleanArchitecture.Application.Features.Products.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CleanArchitecture.Web.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SearchProducts([FromQuery] SearchProductQuery searchProductQuery)
        {
            var productsResponse = await _sender.Send(searchProductQuery);
            return Ok(productsResponse);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var productResponse = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(productResponse);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductCommand updateProductCommand)
        {
            if (id != updateProductCommand.Id)
            {
                return BadRequest("ID in the route does not match ID in the request body.");
            }

            var result = await _sender.Send(updateProductCommand);
            return result ? Ok() : NotFound();
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> CreateProduct([FromBody] AddProductCommand addProductCommand)
        {
            int id = await _sender.Send(addProductCommand);
            return Ok(id);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var productResponse = await _sender.Send(new DeleteProductCommand(id));
            return Ok(productResponse);
        }
    }
}
