using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;

public class HouseholdMember : Entity<HouseholdMemberId>
{
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string? MotherMaidenName { get; set; }
    public int RelationshipToHouseholdHead { get; set; }
    public string? OtherRelation { get; set; }
    public char Sex { get; set; }
    public DateTime Birthday { get; set; }
    public string? FirstQtrClassification { get; set; }
    public string? SecondQtrClassification { get; set; }
    public string? ThirdQtrClassification { get; set; }
    public string? FourthQtrClassification { get; set; }
    public string? Remarks { get; set; }
    public HouseholdId HouseholdId { get; set; } = null!;
    public string? NameOfMother { get; set; }
    public string? NameOfFather { get; set; }
    public bool IsNhts { get; set; }
    public bool? IsInSchool { get; set; }
}
