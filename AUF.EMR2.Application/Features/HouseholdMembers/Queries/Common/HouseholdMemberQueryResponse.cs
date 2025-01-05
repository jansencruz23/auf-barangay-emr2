using AUF.EMR2.Application.Features.HouseholdMembers.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;

public sealed record HouseholdMemberQueryResponse(
    string Id,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    RelationshipToHouseholdHead RelationshipToHouseholdHead,
    string? OtherRelation,
    Sex Sex,
    DateTime Birthday,
    QuarterlyClassificationData? QuarterlyClassification,
    string? Remarks,
    string? NameOfMother,
    string? NameOfFather,
    bool IsNhts,
    bool? IsInSchool,
    Guid HouseholdId
);