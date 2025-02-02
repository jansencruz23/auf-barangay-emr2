﻿using AUF.EMR2.Application.Features.Households.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.Common;

public sealed record MasterlistChildQueryResponse(
    Guid Id,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    Sex Sex,
    DateTime Birthday,
    Guid HouseholdId,
    string? NameOfMother,
    string? NameOfFather,
    bool IsNhts,
    bool? IsInSchool,
    Guid Version
);