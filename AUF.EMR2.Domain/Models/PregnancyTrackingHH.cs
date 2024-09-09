using AUF.EMR2.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Models
{
    public class PregnancyTrackingHh : BaseDomainEntity
    {
        public int Year { get; set; }
        public int BarangayId { get; set; }
        public Barangay Barangay { get; set; }
        public string? BirthingCenter { get; set; }
        public string? BirthingCenterAddress { get; set; }
        public string? ReferralCenter { get; set; }
        public string? ReferralCenterAddress { get; set; }
        public string? BHWName { get; set; }
        public string? MidwifeName { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
    }
}
