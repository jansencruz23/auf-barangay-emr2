using AUF.EMR2.Application.DTOs.Household;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdByHouseholdNo
{
    public record GetHouseholdByHouseholdNoRequest : IRequest<HouseholdDto>
    {
        public string HouseholdNo { get; set; }
    }
}
