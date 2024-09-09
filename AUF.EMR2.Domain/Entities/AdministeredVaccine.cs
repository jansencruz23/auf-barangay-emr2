using AUF.EMR2.Domain.Entities;
using AUF.EMR2.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Entities
{
    public class AdministeredVaccine : BaseDomainEntity
    {
        public Guid VaccinationAppointmentId { get; set; }
        public VaccinationAppointment VaccinationAppointment { get; set; }

        public Guid VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
    }
}
