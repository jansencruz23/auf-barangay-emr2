using AUF.EMR2.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Entities
{
    public class VaccinationRecord : BaseDomainEntity
    {
        public Guid PatientId { get; set; }
        public HouseholdMember Patient { get; set; }
        public string BirthPlace { get; set; }
        public string MotherName { get; set; }
        public int MotherAge { get; set; }
        public DateTime MotherBirthday { get; set; }
        public string FatherName { get; set; }
        public int FatherAge { get; set; }
        public DateTime FatherBirthday { get; set; }
        public string ContactNumber { get; set; }
        public string Weight { get; set; }
        public string TypeOfDelivery { get; set; }
        public string Attended { get; set; }

        public List<VaccinationAppointment>? VaccinationAppointments { get; set; }
    }
}
