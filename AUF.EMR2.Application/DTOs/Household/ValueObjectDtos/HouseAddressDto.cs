namespace AUF.EMR2.Application.DTOs.Household.ValueObjectDtos;

public sealed class HouseAddressDto
{
    public string HouseNoAndStreet { get; set; } = null!;
    public string Barangay { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Province { get; set; } = null!;
}
