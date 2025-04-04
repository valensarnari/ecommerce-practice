﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Orders.Create
{
    public record CreateOrderCommand(int UserId) : IRequest<OrderResponse>;
}
