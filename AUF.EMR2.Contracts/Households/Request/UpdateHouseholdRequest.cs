namespace AUF.EMR2.Contracts.Households.Request;

public class UpdateHouseholdRequest : CreateHouseholdRequest
{
    public Guid Id { get; set; }
    public Guid Version { get; set; }
}
