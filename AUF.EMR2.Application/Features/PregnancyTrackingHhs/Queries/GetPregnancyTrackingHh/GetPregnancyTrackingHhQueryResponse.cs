namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh;

public sealed record GetPregnancyTrackingHhQueryResponse (
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