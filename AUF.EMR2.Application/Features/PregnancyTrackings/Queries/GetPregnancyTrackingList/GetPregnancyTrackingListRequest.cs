﻿using AUF.EMR2.Application.DTOs.PregnancyTracking;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Queries.GetPregnancyTrackingList
{
    public record GetPregnancyTrackingListRequest : IRequest<List<PregnancyTrackingDto>>
    {
        public string HouseholdNo { get; set; }
    }
}
