using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.PregnancyTracking;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Commands.UpdatePregnancyTracking
{
    public record UpdatePregnancyTrackingCommand : IRequest<CommandResponse<Guid>>
    {
        public UpdatePregnancyTrackingDto PregnancyTrackingDto { get; set; }
    }
}
