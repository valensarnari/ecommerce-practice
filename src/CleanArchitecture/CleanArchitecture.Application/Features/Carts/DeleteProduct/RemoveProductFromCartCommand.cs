using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Carts.DeleteProduct
{
    public record RemoveProductFromCartCommand(int UserId, int ProductId, int Quantity) : IRequest<CartResponse?>;
}
