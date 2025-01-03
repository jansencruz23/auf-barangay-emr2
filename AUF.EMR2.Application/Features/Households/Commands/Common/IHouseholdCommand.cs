using AUF.EMR2.Application.Features.Households.Common;

namespace AUF.EMR2.Application.Features.Households.Commands.Common;

public interface IHouseholdCommand
{
    public string HouseholdNo { get; init; }
    public QuarterlyVisitData? QuarterlyVisit { get; init; }
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public string? MotherMaidenName { get; init; }
    public HouseAddressData HouseAddress { get; init; }
    public string ContactNo { get; init; }
    public bool IsNhts { get; init; }
    public PhilhealthData Philhealth { get; init; }
    public bool IsIp { get; init; }
}
