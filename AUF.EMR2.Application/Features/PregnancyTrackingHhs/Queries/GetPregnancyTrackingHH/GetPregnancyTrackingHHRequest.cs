using AUF.EMR2.Application.DTOs.PregnancyTrackingHh;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHH
{
    public record GetPregnancyTrackingHHRequest : IRequest<PregnancyTrackingHhDto>
    {
        public string HouseholdNo { get; set; }
    }
}
