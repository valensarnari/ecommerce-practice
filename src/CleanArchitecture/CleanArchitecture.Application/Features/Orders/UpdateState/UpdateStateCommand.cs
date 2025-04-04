using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Orders.UpdateState
{
    public record UpdateStateCommand(int OrderId, string State) : IRequest<bool>;
}
