﻿using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.CreateHouseholdMember
{
    public record CreateHouseholdMemberCommand : IRequest<CommandResponse<Guid>>
    {
        public CreateHouseholdMemberDto HouseholdMemberDto { get; set; }
    }
}
