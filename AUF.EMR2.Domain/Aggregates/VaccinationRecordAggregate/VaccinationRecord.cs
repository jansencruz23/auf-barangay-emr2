using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.VaccinationRecordAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.VaccinationRecordAggregate;

public class VaccinationRecord : AggregateRoot<VaccinationRecordId>
{

    public HouseholdMemberId PatientId { get; set; } = null!;
    public string BirthPlace { get; set; } = null!;
    public string MotherName { get; set; } = null!;
    public int MotherAge { get; set; }
    public DateTime MotherBirthday { get; set; }
    public string FatherName { get; set; } = null!;
    public int FatherAge { get; set; }
    public DateTime FatherBirthday { get; set; }
    public string ContactNumber { get; set; } = null!;
    public string Weight { get; set; } = null!;
    public string TypeOfDelivery { get; set; } = null!;
    public string Attended { get; set; } = null!;

    public List<VaccinationAppointment>? VaccinationAppointments { get; set; }
}
