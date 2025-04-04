﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.Update
{
    public record UpdateProductCommand(
        int Id, 
        string Name, 
        string Description, 
        decimal Price, 
        int Stock, 
        int CategoryId) : IRequest<bool>;
}
