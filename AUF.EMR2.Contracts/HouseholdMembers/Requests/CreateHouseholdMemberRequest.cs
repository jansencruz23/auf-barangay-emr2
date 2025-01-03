using AUF.EMR2.Contracts.HouseholdMembers.Common.Enums;
using AUF.EMR2.Contracts.HouseholdMembers.Common.ValueObjectDtos;

namespace AUF.EMR2.Contracts.HouseholdMembers.Requests;

public record CreateHouseholdMemberRequest(
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    RelationshipToHouseholdHead RelationshipToHouseholdHead,
    string? OtherRelation,
    Sex Sex,
    DateTime Birthday,
    QuarterlyClassificationDto? QuarterlyClassification,
    string? Remarks,
    Guid HouseholdId,
    string? NameOfMother,
    string? NameOfFather,
    bool IsNhts,
    bool? IsInSchool
);