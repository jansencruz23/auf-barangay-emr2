using AUF.EMR2.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Models
{
    public class VaccinationAppointment : BaseDomainEntity
    {
        public int VaccinationRecordId { get; set; }
        public VaccinationRecord? VaccinationRecord { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public double? Temperature { get; set; }

        public List<AdministeredVaccine>? AdministeredVaccines { get; set; }
    }
}
