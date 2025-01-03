using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.Features.Households.Common;

namespace AUF.EMR2.Application.Features.Households.Queries.Common;

public sealed record HouseholdQueryResponse (
    Guid Id,
    string HouseholdNo,
    QuarterlyVisitData? QuarterlyVisit,
    string FirstName,
    string LastName,
    string? MotherMaidenName,
    HouseAddressData HouseAddress,
    string ContactNo,
    bool IsNhts,
    PhilhealthData Philhealth,
    bool IsIp,
    Guid Version,
    IReadOnlyList<HouseholdMemberDto> HouseholdMembers,
    bool Status = true
);