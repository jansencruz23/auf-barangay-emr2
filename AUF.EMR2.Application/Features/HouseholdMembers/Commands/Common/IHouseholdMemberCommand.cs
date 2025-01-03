using AUF.EMR2.Application.Features.HouseholdMembers.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.Common;

public interface IHouseholdMemberCommand
{
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public string? MotherMaidenName { get; init; }
    public RelationshipToHouseholdHead RelationshipToHouseholdHead { get; init; }
    public string? OtherRelation { get; init; }
    public Sex Sex { get; init; }
    public DateTime Birthday { get; init; }
    public QuarterlyClassificationData? QuarterlyClassification { get; init; }
    public string? Remarks { get; init; }
    public string? NameOfMother { get; init; }
    public string? NameOfFather { get; init; }
    public bool IsNhts { get; init; }
    public bool? IsInSchool { get; init; }
}