using AUF.EMR2.Application.DTOs.HouseholdMember;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMemberListByHouseholdNo
{
    public record GetHouseholdMemberListByHouseholdNoRequest : IRequest<List<HouseholdMemberDto>>
    {
        public string HouseholdNo { get; set; }
    }
}
