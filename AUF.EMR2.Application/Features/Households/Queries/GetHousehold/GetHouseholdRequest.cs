using AUF.EMR2.Application.DTOs.Household;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHousehold
{
    public record GetHouseholdRequest : IRequest<HouseholdDto>
    {
        public Guid Id { get; set; }
    }
}
