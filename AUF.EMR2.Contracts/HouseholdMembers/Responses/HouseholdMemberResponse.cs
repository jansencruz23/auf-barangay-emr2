using AUF.EMR2.Contracts.HouseholdMembers.Common.Enums;
using AUF.EMR2.Contracts.HouseholdMembers.Common.ValueObjectDtos;

namespace AUF.EMR2.Contracts.HouseholdMembers.Responses;

public sealed record HouseholdMemberResponse(
    string Id,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    RelationshipToHouseholdHead RelationshipToHouseholdHead,
    string? OtherRelation,
    Sex Sex,
    DateTime Birthday,
    QuarterlyClassificationDto? QuarterlyClassification,
    string? Remarks,
    string? NameOfMother,
    string? NameOfFather,
    bool IsNhts,
    bool? IsInSchool,
    Guid HouseholdId
);