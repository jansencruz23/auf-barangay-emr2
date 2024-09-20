using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate;

public sealed class Household : AggregateRoot<HouseholdId>
{
    private readonly List<HouseholdMemberId> _householdMemberIds = [];

    public string HouseholdNo { get; set; } = null!;
    public DateTime? FirstQtrVisit { get; set; }
    public DateTime? SecondQtrVisit { get; set; }
    public DateTime? ThirdQtrVisit { get; set; }
    public DateTime? FourthQtrVisit { get; set; }
    public string LastName { get; set; } = null;
    public string FirstName { get; set; } = null!;
    public string? MotherMaidenName { get; set; }
    public string HouseNoAndStreet { get; set; } = null!;
    public string Barangay { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Province { get; set; } = null!;
    public string ContactNo { get; set; } = null!;
    public bool IsNHTS { get; set; }
    public bool IsHeadPhilhealthMember { get; set; }
    public string? PhilhealthNo { get; set; }
    public string? Category { get; set; }
    public bool IsIP { get; set; }


}
