using AUF.EMR2.Application.DTOs.Barangay;
using AUF.EMR2.Application.DTOs.Household;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.PregnancyTrackingHh
{
    public class PregnancyTrackingHhDto : IPregnancyTrackingHhDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int BarangayId { get; set; }
        public BarangayDto Barangay { get; set; }
        public string? BirthingCenter { get; set; }
        public string? BirthingCenterAddress { get; set; }
        public string? ReferralCenter { get; set; }
        public string? ReferralCenterAddress { get; set; }
        public string? BHWName { get; set; }
        public string? MidwifeName { get; set; }
        public int HouseholdId { get; set; }
        public HouseholdOnlyDto Household { get; set; }
        public Guid Version { get; set; }
    }
}
