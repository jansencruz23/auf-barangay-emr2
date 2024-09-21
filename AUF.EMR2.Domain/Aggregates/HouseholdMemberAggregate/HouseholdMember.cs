using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;

public class HouseholdMember : AggregateRoot<HouseholdMemberId>
{
    public string LastName { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string? MotherMaidenName { get; private set; }
    public RelationshipToHouseholdHead RelationshipToHouseholdHead { get; private set; }
    public string? OtherRelation { get; private set; }
    public Sex Sex { get; private set; }
    public DateTime Birthday { get; private set; }
    public string? FirstQtrClassification { get; private set; }
    public string? SecondQtrClassification { get; private set; }
    public string? ThirdQtrClassification { get; private set; }
    public string? FourthQtrClassification { get; private set; }
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
        string? firstQtrClassification,
        string? secondQtrClassification,
        string? thirdQtrClassification,
        string? fourthQtrClassification,
        string? remarks,
        string? nameOfMother,
        string? nameOfFather,
        bool isNhts,
        bool? isInSchool)
        : base(householdMemberId)
    {
        LastName = lastName;
        FirstName = firstName;
        MotherMaidenName = motherMaidenName;
        RelationshipToHouseholdHead = relationshipToHouseholdHead;
        OtherRelation = otherRelation;
        Sex = sex;
        Birthday = birthday;
        FirstQtrClassification = firstQtrClassification;
        SecondQtrClassification = secondQtrClassification;
        ThirdQtrClassification = thirdQtrClassification;
        FourthQtrClassification = fourthQtrClassification;
        Remarks = remarks;
        NameOfMother = nameOfMother;
        NameOfFather = nameOfFather;
        IsNhts = isNhts;
        IsInSchool = isInSchool;
    }

    public static HouseholdMember Create(
        string lastName,
        string firstName,
        string? motherMaidenName,
        RelationshipToHouseholdHead relationshipToHouseholdHead,
        string? otherRelation,
        Sex sex,
        DateTime birthday,
        string? firstQtrClassification,
        string? secondQtrClassification,
        string? thirdQtrClassification,
        string? fourthQtrClassification,
        string? remarks,
        string? nameOfMother,
        string? nameOfFather,
        bool isNhts,
        bool? isInSchool)
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
            firstQtrClassification: firstQtrClassification,
            secondQtrClassification: secondQtrClassification,
            thirdQtrClassification: thirdQtrClassification,
            fourthQtrClassification: fourthQtrClassification,
            remarks: remarks,
            nameOfMother: nameOfMother,
            nameOfFather: nameOfFather,
            isNhts: isNhts,
            isInSchool: isInSchool);
    }

    private HouseholdMember() { }
}
