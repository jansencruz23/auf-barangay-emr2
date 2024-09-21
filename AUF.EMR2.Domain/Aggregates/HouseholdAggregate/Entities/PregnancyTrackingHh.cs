using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Entities;

public sealed class PregnancyTrackingHh : Entity<PregnancyTrackinggHhId>
{
    public int Year { get; private set; }
    public Guid BarangayId { get; private set; }
    public Barangay Barangay { get; private set; }
    public string? BirthingCenter { get; private set; }
    public string? BirthingCenterAddress { get; private set; }
    public string? ReferralCenter { get; private set; }
    public string? ReferralCenterAddress { get; private set; }
    public string? BHWName { get; private set; }
    public string? MidwifeName { get; private set; }
    public Guid HouseholdId { get; private set; }
    public Household Household { get; private set; }
}
