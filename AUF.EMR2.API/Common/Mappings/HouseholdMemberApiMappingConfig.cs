﻿using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;
using AUF.EMR2.Contracts.HouseholdMembers.Responses;
using AUF.EMR2.Contracts.Households.Requests;
using Mapster;

namespace AUF.EMR2.API.Common.Mappings;

public class HouseholdMemberApiMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateHouseholdCommand, CreateHouseholdRequest>();
        config.NewConfig<HouseholdMemberQueryResponse, HouseholdMemberResponse>();
    }
}
