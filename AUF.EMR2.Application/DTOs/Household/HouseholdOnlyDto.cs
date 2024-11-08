﻿namespace AUF.EMR2.Application.DTOs.Household;

public class HouseholdOnlyDto : IHouseholdDto
{
    public Guid Id { get; set; }
    public bool Status { get; set; } = true;
    public string HouseholdNo { get; set; } = null!;
    public DateTime? FirstQtrVisit { get; set; }
    public DateTime? SecondQtrVisit { get; set; }
    public DateTime? ThirdQtrVisit { get; set; }
    public DateTime? FourthQtrVisit { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string? MotherMaidenName { get; set; }
    //public HouseAddressDto HouseAddress { get; set; }
    public string ContactNo { get; set; } = null!;
    public bool IsNhts { get; set; }
    //public PhilhealthDto Philhealth { get; set; }
    public bool IsIp { get; set; }
}
