using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates;

public class AdministeredVaccine 
{
    public Guid VaccinationAppointmentId { get; set; }
    public VaccinationAppointment VaccinationAppointment { get; set; }

    public Guid VaccineId { get; set; }
    public Vaccine Vaccine { get; set; }
}
