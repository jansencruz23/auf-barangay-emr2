using AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate;

public sealed class PregnancyTrackingHh : AggregateRoot<PregnancyTrackingHhId>
{
    public int Year { get; private set; }
    public string? BirthingCenter { get; private set; }
    public string? BirthingCenterAddress { get; private set; }
    public string? ReferralCenter { get; private set; }
    public string? ReferralCenterAddress { get; private set; }
    public string? BHWName { get; private set; }
    public string? MidwifeName { get; private set; }

    public HouseholdId HouseholdId { get; private set; } = null!;
    public BarangayId BarangayId { get; private set; } = null!;

    private PregnancyTrackingHh(
        PregnancyTrackingHhId pregnancyTrackinggHhId,
        int year,
        string? birthingCenter,
        string? birthingCenterAddress,
        string? referralCenter,
        string? referralCenterAddress,
        string? bHWName,
        string? midwifeName)
        : base(pregnancyTrackinggHhId)
    {
        Year = year;
        BirthingCenter = birthingCenter;
        BirthingCenterAddress = birthingCenterAddress;
        ReferralCenter = referralCenter;
        ReferralCenterAddress = referralCenterAddress;
        BHWName = bHWName;
        MidwifeName = midwifeName;
    }

    public static PregnancyTrackingHh Create(
        int year,
        string? birthingCenter,
        string? birthingCenterAddress,
        string? referralCenter,
        string? referralCenterAddress,
        string? bHWName,
        string? midwifeName)
    {
        return new PregnancyTrackingHh(
            PregnancyTrackingHhId.Create(),
            year: year,
            birthingCenter: birthingCenter,
            birthingCenterAddress: birthingCenterAddress,
            referralCenter: referralCenter,
            referralCenterAddress: referralCenterAddress,
            bHWName: bHWName,
            midwifeName: midwifeName);
    }

    private PregnancyTrackingHh() { }
}