﻿using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold
{
    public record CreateHouseholdCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateHouseholdDto HouseholdDto { get; set; }
    }
}
