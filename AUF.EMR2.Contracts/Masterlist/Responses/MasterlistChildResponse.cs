using AUF.EMR2.Contracts.HouseholdMembers.Common.Enums;
using AUF.EMR2.Contracts.Households.Responses;

namespace AUF.EMR2.Contracts.Masterlist.Responses;

public sealed record MasterlistChildResponse(
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