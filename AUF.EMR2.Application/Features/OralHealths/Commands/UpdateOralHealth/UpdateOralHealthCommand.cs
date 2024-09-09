using AUF.EMR2.Application.DTOs.OralHealth;
using AUF.EMR2.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.OralHealths.Commands.UpdateOralHealth
{
    public record UpdateOralHealthCommand : IRequest<BaseCommandResponse<Guid>>
    {
        public UpdateOralHealthDto OralHealthDto { get; set; }
    }
}
