using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.OralHealth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.OralHealths.Commands.UpdateOralHealth
{
    public record UpdateOralHealthCommand : IRequest<CommandResponse<Guid>>
    {
        public UpdateOralHealthDto OralHealthDto { get; set; }
    }
}
