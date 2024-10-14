namespace AUF.EMR2.Contracts.PregnancyTrackingHhs.Requests;

public sealed record UpdatePregnancyTrackingHhRequest(
    Guid Id,
    int Year,
    Guid BarangayId,
    string? BirthingCenter,
    string? BirthingCenterAddress,
    string ReferralCenter,
    string? ReferralCenterAddress,
    string? BhwName,
    string? MidwifeName,
    Guid HouseholdId,
    Guid Version
);