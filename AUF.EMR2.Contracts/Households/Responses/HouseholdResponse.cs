using AUF.EMR2.Contracts.Households.Common.ValueObjectDtos;

namespace AUF.EMR2.Contracts.Households.Responses;

public sealed record HouseholdResponse(
    Guid Id,
    string HouseholdNo,
    DateTime? FirstQtrVisit,
    DateTime? SecondQtrVisit,
    DateTime? ThirdQtrVisit,
    DateTime? FourthQtrVisit,
    string FirstName,
    string LastName,
    string? MotherMaidenName,
    HouseAddressDto HouseAddress,
    string ContactNo,
    bool IsNhts,
    PhilhealthDto Philhealth,
    bool IsIp,
    Guid Version,
    //IReadOnlyList<HouseholdMemberDto> HouseholdMembers,
    bool Status = true
);
