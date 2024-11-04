using AUF.EMR2.Domain.Aggregates.VaccinationRecordAggregate;

namespace AUF.EMR2.Domain.Aggregates;

public class VaccinationAppointment 
{
    public Guid VaccinationRecordId { get; set; }
    public VaccinationRecord? VaccinationRecord { get; set; }
    public DateTime VaccinationDate { get; set; }
    public string Weight { get; set; }
    public string Height { get; set; }
    public double? Temperature { get; set; }

    public List<AdministeredVaccine>? AdministeredVaccines { get; set; }
}
