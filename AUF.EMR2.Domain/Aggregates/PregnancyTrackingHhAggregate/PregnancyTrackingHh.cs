using AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using AUF.EMR2.Domain.Common.Models;
using ErrorOr;

namespace AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate;

public sealed class PregnancyTrackingHh : AggregateRoot<PregnancyTrackingHhId>
{
    public int Year { get; private set; }
    public string? BirthingCenter { get; private set; }
    public string? BirthingCenterAddress { get; private set; }
    public string? ReferralCenter { get; private set; }
    public string? ReferralCenterAddress { get; private set; }
    public string? BhwName { get; private set; }
    public string? MidwifeName { get; private set; }

    public HouseholdId HouseholdId { get; private set; } = null!;
    //public BarangayId BarangayId { get; private set; } = null!;

    private PregnancyTrackingHh(
        PregnancyTrackingHhId pregnancyTrackinggHhId,
        int year,
        string? birthingCenter,
        string? birthingCenterAddress,
        string? referralCenter,
        string? referralCenterAddress,
        string? bHWName,
        string? midwifeName,
        HouseholdId householdId)
        : base(pregnancyTrackinggHhId)
    {
        Year = year;
        BirthingCenter = birthingCenter;
        BirthingCenterAddress = birthingCenterAddress;
        ReferralCenter = referralCenter;
        ReferralCenterAddress = referralCenterAddress;
        BhwName = bHWName;
        MidwifeName = midwifeName;
        HouseholdId = householdId;
    }

    public static PregnancyTrackingHh Create(
        int year,
        string? birthingCenter,
        string? birthingCenterAddress,
        string? referralCenter,
        string? referralCenterAddress,
        string? bwhName,
        string? midwifeName,
        HouseholdId householdId)
    {
        return new PregnancyTrackingHh(
            PregnancyTrackingHhId.Create(),
            year: year,
            birthingCenter: birthingCenter,
            birthingCenterAddress: birthingCenterAddress,
            referralCenter: referralCenter,
            referralCenterAddress: referralCenterAddress,
            bHWName: bwhName,
            midwifeName: midwifeName,
            householdId: householdId);
    }

    public ErrorOr<PregnancyTrackingHhId> Update(
        int year,
        string? birthingCenter,
        string? birthingCenterAddress,
        string? referralCenter,
        string? referralCenterAddress,
        string? bwhName,
        string? midwifeName)
    {
        Year = year;
        BirthingCenter = birthingCenter;
        BirthingCenterAddress = birthingCenterAddress;
        ReferralCenter = referralCenter;
        ReferralCenterAddress = referralCenterAddress;
        BhwName = bwhName;
        MidwifeName = midwifeName;

        return Id;
    }

    public ErrorOr<PregnancyTrackingHhId> Delete()
    {
        if (Status == false)
        {
            return Errors.PregnancyTrackingHh.NotFound;
        }

        Status = false;
        return Id;
    }

    private PregnancyTrackingHh() { }
}