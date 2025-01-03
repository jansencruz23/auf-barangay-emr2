using AUF.EMR2.Contracts.Households.Common.ValueObjectDtos;

namespace AUF.EMR2.Contracts.Households.Requests;

public sealed record UpdateHouseholdRequest(
    Guid Id,
    Guid Version,
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
