﻿using AUF.EMR2.Application.DTOs.OralHealth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthPregnantTwentyToFourtyNine
{
    public record GetOralHealthPregnantTwentyToFourtyNineRequest : IRequest<List<OralHealthDto>>
    {
        public string HouseholdNo { get; set; }
    }
}
