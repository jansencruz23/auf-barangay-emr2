using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.UpdateHouseholdMember
{
    public record UpdateHouseholdMemberCommand : IRequest<BaseCommandResponse<Guid>>
    {
        public UpdateHouseholdMemberDto HouseholdMemberDto { get; set; }
    }
}
