using CleanArchitecture.Application.Features.Carts.AddProduct;
using CleanArchitecture.Application.Features.Carts.DeleteProduct;
using CleanArchitecture.Application.Features.Carts.GetByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;

namespace CleanArchitecture.Web.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ISender _sender;

        public CartController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetCartByUser([FromRoute] int userId)
        {
            var cartResponse = await _sender.Send(new GetCartByUserQuery(userId));
            return Ok(cartResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCart([FromBody] AddProductToCartCommand addProductToCartCommand)
        {
            var cartResponse = await _sender.Send(addProductToCartCommand);
            return Ok(cartResponse);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProductFromCart([FromBody] RemoveProductFromCartCommand removeProductFromCartCommand)
        {
            var cartResponse = await _sender.Send(removeProductFromCartCommand);
            return Ok(cartResponse);
        }
    }
}
