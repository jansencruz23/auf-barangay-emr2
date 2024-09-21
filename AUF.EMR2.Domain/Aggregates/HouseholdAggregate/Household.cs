﻿using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate;

public sealed class Household : AggregateRoot<HouseholdId>
{
    private readonly List<HouseholdMemberId> _householdMemberIds = [];

    public string HouseholdNo { get; private set; } = null!;
    public DateTime? FirstQtrVisit { get; private set; }
    public DateTime? SecondQtrVisit { get; private set; }
    public DateTime? ThirdQtrVisit { get; private set; }
    public DateTime? FourthQtrVisit { get; private set; }
    public string LastName { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string? MotherMaidenName { get; private set; }
    public HouseAddress Address { get; private set; } = null!;
    public string ContactNo { get; private set; } = null!;
    public bool IsNhts { get; }
    public bool IsNHTS { get; private set; }
    public Philhealth Philhealth { get; private set; } = null!;
    public bool IsIp { get; }
    public bool IsIP { get; private set; }

    public IReadOnlyList<HouseholdMemberId> HouseholdMemberIds => _householdMemberIds.AsReadOnly();

    private Household(
        HouseholdId householdId,
        string householdNo,
        DateTime? firstQtrVisit,
        DateTime? secondQtrVisit,
        DateTime? thirdQtrVisit,
        DateTime? fourthQtrVisit,
        string lastName,
        string firstName,
        string? motherMaidenName,
        HouseAddress address,
        string contactNo,
        bool isNhts,
        Philhealth philhealth,
        bool isIp)
        : base(householdId)
    {
        HouseholdNo = householdNo;
        FirstQtrVisit = firstQtrVisit;
        SecondQtrVisit = secondQtrVisit;
        ThirdQtrVisit = thirdQtrVisit;
        FourthQtrVisit = fourthQtrVisit;
        LastName = lastName;
        FirstName = firstName;
        MotherMaidenName = motherMaidenName;
        Address = address;
        ContactNo = contactNo;
        IsNhts = isNhts;
        Philhealth = philhealth;
        IsIp = isIp;
    }

    public static Household Create(
        string householdNo,
        DateTime? firstQtrVisit,
        DateTime? secondQtrVisit,
        DateTime? thirdQtrVisit,
        DateTime? fourthQtrVisit,
        string lastName,
        string firstName,
        string? motherMaidenName,
        HouseAddress address,
        string contactNo,
        bool isNhts,
        Philhealth philhealth,
        bool isIp)
    {
        return new Household(
            householdId: HouseholdId.Create(),
            householdNo: householdNo,
            firstQtrVisit: firstQtrVisit,
            secondQtrVisit: secondQtrVisit,
            thirdQtrVisit: thirdQtrVisit,
            fourthQtrVisit: fourthQtrVisit,
            lastName: lastName,
            firstName: firstName,
            motherMaidenName: motherMaidenName,
            address: address,
            contactNo: contactNo,
            isNhts: isNhts,
            philhealth: philhealth,
            isIp: isIp);
    }

    private Household() { }
}