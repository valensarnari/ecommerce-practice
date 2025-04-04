﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Users.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<AuthenticationResponse>;
}
