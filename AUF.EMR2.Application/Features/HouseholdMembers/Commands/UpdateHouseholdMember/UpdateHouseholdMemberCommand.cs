using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.UpdateHouseholdMember
{
    public record UpdateHouseholdMemberCommand : IRequest<CommandResponse<Guid>>
    {
        public UpdateHouseholdMemberDto HouseholdMemberDto { get; set; }
    }
}
