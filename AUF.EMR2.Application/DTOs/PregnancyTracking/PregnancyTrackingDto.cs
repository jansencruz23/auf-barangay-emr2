using AUF.EMR2.Application.DTOs.HouseholdMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.PregnancyTracking
{
    public class PregnancyTrackingDto : IPregnancyTrackingDto
    {
        public int Id { get; set; }
        public int HouseholdMemberId { get; set; }
        public HouseholdMemberOnlyDto HouseholdMember { get; set; }
        public int Age { get; set; }
        public int Gravidity { get; set; }
        public int Parity { get; set; }
        public DateTime ExpectedDateOfDelivery { get; set; }
        public DateTime? FirstAntenatalCheckUp { get; set; }
        public DateTime? SecondAntenatalCheckUp { get; set; }
        public DateTime? ThirdAntenatalCheckUp { get; set; }
        public DateTime? MoreCheckUp { get; set; }
        public string PregnancyOutcome { get; set; }
        public DateTime? PostnatalCheckUp24hrs { get; set; }
        public DateTime? PostnatalCheckUp7days { get; set; }
        public DateTime? LiveBirth { get; set; }
        public DateTime? MaternalDeath { get; set; }
        public DateTime? StillBirth { get; set; }
        public DateTime? EarlyNewbornDeath { get; set; }
        public Guid Version { get; set; }
    }
}
