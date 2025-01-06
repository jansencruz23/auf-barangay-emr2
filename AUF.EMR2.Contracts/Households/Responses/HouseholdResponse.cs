using AUF.EMR2.Contracts.HouseholdMembers.Responses;
using AUF.EMR2.Contracts.Households.Common.ValueObjectDtos;

namespace AUF.EMR2.Contracts.Households.Responses;

public sealed record HouseholdResponse(
    Guid Id,
    string HouseholdNo,
    QuarterlyVisitDto QuarterlyVisit,
    string FirstName,
    string LastName,
    string? MotherMaidenName,
    HouseAddressDto HouseAddress,
    string ContactNo,
    bool IsNhts,
    PhilhealthDto Philhealth,
    bool IsIp,
    Guid Version,
    IReadOnlyList<HouseholdMemberResponse> HouseholdMembers,
    bool Status = true
);
