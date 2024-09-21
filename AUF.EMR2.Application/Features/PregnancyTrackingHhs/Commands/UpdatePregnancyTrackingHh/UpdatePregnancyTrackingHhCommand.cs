﻿using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.PregnancyTrackingHh;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Commands.UpdatePregnancyTrackingHh
{
    public record UpdatePregnancyTrackingHhCommand : IRequest<BaseCommandResponse<Guid>>
    {
        public UpdatePregnancyTrackingHhDto PregnancyTrackingHHDto { get; set; }
    }
}
