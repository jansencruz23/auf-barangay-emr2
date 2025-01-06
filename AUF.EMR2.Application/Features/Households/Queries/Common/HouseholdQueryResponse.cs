using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using AUF.EMR2.Application.Features.Households.Common;

namespace AUF.EMR2.Application.Features.Households.Queries.Common;

public sealed class HouseholdQueryResponse
{
    public Guid Id { get; init; }
    public string HouseholdNo { get; init; } = string.Empty;
    public QuarterlyVisitData? QuarterlyVisit { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? MotherMaidenName { get; init; }
    public HouseAddressData HouseAddress { get; init; } = null!;
    public string ContactNo { get; init; } = string.Empty;
    public bool IsNhts { get; init; }
    public PhilhealthData Philhealth { get; init; } = null!;
    public bool IsIp { get; init; }
    public Guid Version { get; init; }
    public List<HouseholdMemberQueryResponse> HouseholdMembers { get; private set; } = [];
    public bool Status { get; init; }

    public void SetHouseholdMembers(List<HouseholdMemberQueryResponse> householdMembers)
    {
        HouseholdMembers = householdMembers;
    }
}