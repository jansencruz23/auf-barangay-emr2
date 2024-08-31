using AUF.EMR2.Application.DTOs.HouseholdMember;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMember
{
    public record GetHouseholdMemberRequest : IRequest<HouseholdMemberDto>
    {
        public int Id { get; set; }
    }
}
