using AUF.EMR2.Application.DTOs.Household.ValueObjects;

namespace AUF.EMR2.Application.DTOs.Household;

public interface IHouseholdDto
{
    public string HouseholdNo { get; set; }
    public DateTime? FirstQtrVisit { get; set; }
    public DateTime? SecondQtrVisit { get; set; }
    public DateTime? ThirdQtrVisit { get; set; }
    public DateTime? FourthQtrVisit { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? MotherMaidenName { get; set; }
    public HouseAddressDto HouseAddress { get; set; } 
    public string ContactNo { get; set; }
    public bool IsNHTS { get; set; }
    public PhilhealthDto Philhealth { get; set; }
    public bool IsIP { get; set; }
}
