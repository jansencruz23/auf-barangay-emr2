using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Events;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using AUF.EMR2.Domain.Common.Models;
using ErrorOr;

namespace AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;

public sealed class HouseholdMember : AggregateRoot<HouseholdMemberId>
{
    public string LastName { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string? MotherMaidenName { get; private set; }
    public RelationshipToHouseholdHead RelationshipToHouseholdHead { get; private set; }
    public string? OtherRelation { get; private set; }
    public Sex Sex { get; private set; }
    public DateTime Birthday { get; private set; }
    public QuarterlyClassification? QuarterlyClassification { get; private set; }
    public string? Remarks { get; private set; }
    public string? NameOfMother { get; private set; }
    public string? NameOfFather { get; private set; }
    public bool IsNhts { get; private set; }
    public bool? IsInSchool { get; private set; }

    public HouseholdId HouseholdId { get; private set; } = null!;

    private HouseholdMember(
        HouseholdMemberId householdMemberId,
        string lastName,
        string firstName,
        string? motherMaidenName,
        RelationshipToHouseholdHead relationshipToHouseholdHead,
        string? otherRelation,
        Sex sex,
        DateTime birthday,
        QuarterlyClassification? quarterlyClassification,
        string? remarks,
        string? nameOfMother,
        string? nameOfFather,
        bool isNhts,
        bool? isInSchool,
        Guid householdId)
        : base(householdMemberId)
    {
        LastName = lastName;
        FirstName = firstName;
        MotherMaidenName = motherMaidenName;
        RelationshipToHouseholdHead = relationshipToHouseholdHead;
        OtherRelation = otherRelation;
        Sex = sex;
        Birthday = birthday;
        QuarterlyClassification = quarterlyClassification;
        Remarks = remarks;
        NameOfMother = nameOfMother;
        NameOfFather = nameOfFather;
        IsNhts = isNhts;
        IsInSchool = isInSchool;
        HouseholdId = HouseholdId.Create(householdId);
    }

    public static HouseholdMember Create(
        string lastName,
        string firstName,
        string? motherMaidenName,
        RelationshipToHouseholdHead relationshipToHouseholdHead,
        string? otherRelation,
        Sex sex,
        DateTime birthday,
        QuarterlyClassification? quarterlyClassification,
        string? remarks,
        string? nameOfMother,
        string? nameOfFather,
        bool isNhts,
        bool? isInSchool,
        Guid householdId)
    {
        return new HouseholdMember(
            householdMemberId: HouseholdMemberId.Create(),
            lastName: lastName,
            firstName: firstName,
            motherMaidenName: motherMaidenName,
            relationshipToHouseholdHead: relationshipToHouseholdHead,
            otherRelation: otherRelation,
            sex: sex,
            birthday: birthday,
            quarterlyClassification: quarterlyClassification,
            remarks: remarks,
            nameOfMother: nameOfMother,
            nameOfFather: nameOfFather,
            isNhts: isNhts,
            isInSchool: isInSchool,
            householdId: householdId);
    }

    public ErrorOr<HouseholdMemberId> Update(
        string lastName,
        string firstName,
        string? motherMaidenName,
        RelationshipToHouseholdHead relationshipToHouseholdHead,
        string? otherRelation,
        Sex sex,
        DateTime birthday,
        QuarterlyClassification? quarterlyClassification,
        string? remarks,
        string? nameOfMother,
        string? nameOfFather,
        bool isNhts,
        bool? isInSchool)
    {
        LastName = lastName;
        FirstName = firstName;
        MotherMaidenName = motherMaidenName;
        RelationshipToHouseholdHead = relationshipToHouseholdHead;
        OtherRelation = otherRelation;
        Sex = sex;
        Birthday = birthday;
        QuarterlyClassification = quarterlyClassification;
        Remarks = remarks;
        NameOfMother = nameOfMother;
        NameOfFather = nameOfFather;
        IsNhts = isNhts;
        IsInSchool = isInSchool;

        return Id;
    }

    public ErrorOr<HouseholdMemberId> Delete()
    {
        if (!Status)
        {
            return Errors.HouseholdMember.NotFound;
        }

        Status = false;
        AddDomainEvent(new HouseholdMemberDeleted(Id));

        return Id;
    }

    private HouseholdMember() { }
    private HouseholdMember(HouseholdMemberId householdMemberId) : base(householdMemberId) { }
}
