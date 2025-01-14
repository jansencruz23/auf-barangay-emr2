﻿using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.Households.Commands.Common;
using AUF.EMR2.Application.Features.Households.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;

public sealed record CreateHouseholdCommand(
    string HouseholdNo,
    QuarterlyVisitData? QuarterlyVisit,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    HouseAddressData HouseAddress,
    string ContactNo,
    bool IsNhts,
    PhilhealthData Philhealth,
    bool IsIp
) : IRequest<ErrorOr<CommandResponse<Guid>>>, IHouseholdCommand;