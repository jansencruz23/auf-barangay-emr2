using AUF.EMR2.Application.DTOs.PregnancyTracking;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Queries.GetPrintPregnancyTrackingRecords
{
    public record GetPrintPregnancyTrackingRecordsRequest : IRequest<PrintPregnancyTrackingDto>
    {
        public string HouseholdNo { get; set; }
    }
}
