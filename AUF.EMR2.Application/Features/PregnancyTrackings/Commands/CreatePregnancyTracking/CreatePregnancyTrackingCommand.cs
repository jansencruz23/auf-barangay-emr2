using AUF.EMR2.Application.DTOs.PregnancyTracking;
using AUF.EMR2.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Commands.CreatePregnancyTracking
{
    public record CreatePregnancyTrackingCommand : IRequest<BaseCommandResponse<Guid>>
    {
        public CreatePregnancyTrackingDto PregnancyTrackingDto { get; set; }
    }
}
