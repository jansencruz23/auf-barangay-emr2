using AUF.EMR2.Contracts.Households.Common.ValueObjectDtos;

namespace AUF.EMR2.Contracts.Households.Requests;

public sealed record CreateHouseholdRequest(
    string HouseholdNo,
    QuarterlyVisitDto QuarterlyVisit,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    HouseAddressDto HouseAddress,
    string ContactNo,
    bool IsNhts,
    PhilhealthDto Philhealth,
    bool IsIp
);
