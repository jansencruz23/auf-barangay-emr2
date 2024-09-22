using AUF.EMR2.Application.Features.Households.Common;

namespace AUF.EMR2.Application.Features.Households.Commands.Common;

public interface IHouseholdCommand
{
    public string HouseholdNo { get; init; }
    public DateTime? FirstQtrVisit { get; init; }
    public DateTime? SecondQtrVisit { get; init; }
    public DateTime? ThirdQtrVisit { get; init; }
    public DateTime? FourthQtrVisit { get; init; }
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public string? MotherMaidenName { get; init; }
    public HouseAddressRequest HouseAddress { get; init; }
    public string ContactNo { get; init; }
    public bool IsNhts { get; init; }
    public PhilhealthRequest Philhealth { get; init; }
    public bool IsIp { get; init; }
}
