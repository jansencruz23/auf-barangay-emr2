namespace AUF.EMR2.Domain.Aggregates;

public class Vaccine 
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public List<AdministeredVaccine> AdministeredVaccines { get; set; }
}
