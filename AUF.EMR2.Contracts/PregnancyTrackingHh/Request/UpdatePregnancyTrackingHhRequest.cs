namespace AUF.EMR2.Contracts.PregnancyTrackingHh.Request;

public sealed class UpdatePregnancyTrackingHhRequest
{
    public Guid Id { get; set; }
    public int Year { get; set; }
    public Guid BarangayId { get; set; }
    public string? BirthingCenter { get; set; }
    public string? BirthingCenterAddress { get; set; }
    public string? ReferralCenter { get; set; }
    public string? ReferralCenterAddress { get; set; }
    public string? BHWName { get; set; }
    public string? MidwifeName { get; set; }
    public Guid HouseholdId { get; set; }
    public Guid Version { get; set; }
}
