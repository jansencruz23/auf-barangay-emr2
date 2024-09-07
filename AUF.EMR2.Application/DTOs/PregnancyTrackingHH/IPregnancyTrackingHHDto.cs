using AUF.EMR2.Application.DTOs.Barangay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.PregnancyTrackingHH
{
    public interface IPregnancyTrackingHHDto
    {
        public int Year { get; set; }
        public int BarangayId { get; set; }
        public string? BirthingCenter { get; set; }
        public string? BirthingCenterAddress { get; set; }
        public string? ReferralCenter { get; set; }
        public string? ReferralCenterAddress { get; set; }
        public string? BHWName { get; set; }
        public string? MidwifeName { get; set; }
        public int HouseholdId { get; set; }
    }
}
