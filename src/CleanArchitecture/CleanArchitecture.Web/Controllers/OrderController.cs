using CleanArchitecture.Application.Features.Orders.Create;
using CleanArchitecture.Application.Features.Orders.GetByUser;
using CleanArchitecture.Application.Features.Orders.UpdateState;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetOrdersByUser([FromRoute] int userId)
        {
            var orderResponse = await _sender.Send(new GetOrderByUserQuery(userId));
            return Ok(orderResponse);
        }

        [HttpPut("{orderId:int}")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> UpdateOrderState([FromRoute] int orderId, [FromBody] UpdateStateCommand command)
        {
            if (orderId != command.OrderId)
            {
                return BadRequest("ID in the route does not match ID in the request body.");
            }

            var result = await _sender.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderResponse = await _sender.Send(command);
            return Ok(orderResponse);
        }
    }
}
