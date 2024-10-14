namespace AUF.EMR2.Contracts.PregnancyTrackingHhs.Responses;

public sealed record PregnancyTrackingHhResponse(
    Guid Id,
    int Year,
    Guid BarangayId,
    string? BirthingCenter,
    string? BirthingCenterAddress,
    string? ReferralCenter,
    string? ReferralCenterAddress,
    string? BHWName,
    string? MidwifeName,
    Guid HouseholdId,
    Guid Version
);