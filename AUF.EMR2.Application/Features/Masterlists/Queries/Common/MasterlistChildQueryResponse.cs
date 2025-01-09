using AUF.EMR2.Application.Features.Households.Queries.Common;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.Common;

public sealed record MasterlistChildQueryResponse(
    Guid Id,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    char Sex,
    DateTime Birthday,
    Guid HouseholdId,
    HouseholdQueryResponse Household,
    string? NameOfMother,
    string? NameOfFather,
    bool IsNhts,
    bool? IsInSchool,
    Guid Version
);