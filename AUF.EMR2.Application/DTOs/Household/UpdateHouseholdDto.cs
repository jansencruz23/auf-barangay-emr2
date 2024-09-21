namespace AUF.EMR2.Application.DTOs.Household;

public class UpdateHouseholdDto : CreateHouseholdDto
{
    public Guid Id { get; set; }
    public Guid Version { get; set; }
}
