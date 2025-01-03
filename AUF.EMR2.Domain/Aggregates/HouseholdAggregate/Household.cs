using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Events;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using AUF.EMR2.Domain.Common.Models;
using ErrorOr;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate;

public sealed class Household : AggregateRoot<HouseholdId>
{
    //private readonly List<HouseholdMemberId> _householdMemberIds = [];

    public string HouseholdNo { get; private set; } = null!;
    public QuarterlyVisit? QuarterlyVisit { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string? MotherMaidenName { get; private set; }
    public HouseAddress HouseAddress { get; private set; } = null!;
    public string ContactNo { get; private set; } = null!;
    public bool IsNhts { get; private set; }
    public Philhealth Philhealth { get; private set; } = null!;
    public bool IsIp { get; private set; }

    //public IReadOnlyList<HouseholdMemberId> HouseholdMemberIds => _householdMemberIds.AsReadOnly();

    private Household(HouseholdId householdId) : base(householdId) { }

    public static Household Create(
        string householdNo,
        QuarterlyVisit quarterlyVisit,
        string lastName,
        string firstName,
        string? motherMaidenName,
        HouseAddress houseAddress,
        string contactNo,
        bool isNhts,
        Philhealth philhealth,
        bool isIp)
    {
        var household = new Household(HouseholdId.Create())
        {
            HouseholdNo = householdNo,
            QuarterlyVisit = quarterlyVisit,
            LastName = lastName,
            FirstName = firstName,
            MotherMaidenName = motherMaidenName,
            HouseAddress = houseAddress,
            ContactNo = contactNo,
            IsNhts = isNhts,
            Philhealth = philhealth,
            IsIp = isIp
        };

        household.AddDomainEvent(new HouseholdCreated(household));
        return household;
    }

    public ErrorOr<HouseholdId> Update(
        string householdNo,
        QuarterlyVisit quarterlyVisit,
        string lastName,
        string firstName,
        string? motherMaidenName,
        HouseAddress houseAddress,
        string contactNo,
        bool isNhts,
        Philhealth philhealth,
        bool isIp)
    {
        if (string.IsNullOrWhiteSpace(householdNo))
        {
            return Errors.Household.EmptyHouseholdNo;
        }
        
        HouseholdNo = householdNo;
        QuarterlyVisit = quarterlyVisit;
        LastName = lastName;
        FirstName = firstName;
        MotherMaidenName = motherMaidenName;
        HouseAddress = houseAddress;
        ContactNo = contactNo;
        IsNhts = isNhts;
        Philhealth = philhealth;
        IsIp = isIp;

        return Id;
    }

    public ErrorOr<HouseholdId> Delete()
    {
        if (Status == false)
        {
            return Errors.Household.NotFound;
        }

        Status = false;
        AddDomainEvent(new HouseholdDeleted(Id));

        return Id;
    }

    private Household() { }
}