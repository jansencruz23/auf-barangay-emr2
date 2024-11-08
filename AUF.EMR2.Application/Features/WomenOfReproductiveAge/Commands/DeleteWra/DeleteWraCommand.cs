﻿using AUF.EMR2.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Commands.DeleteWra
{
    public record DeleteWraCommand : IRequest<CommandResponse<Guid>>
    {
        public Guid Id { get; set; }
    }
}
