using AUF.EMR2.Application.DTOs.PregnancyTracking;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Queries.GetPregnancyTracking
{
    public record GetPregnancyTrackingRequest : IRequest<PregnancyTrackingDto>
    {
        public Guid Id { get; set; }
    }
}
