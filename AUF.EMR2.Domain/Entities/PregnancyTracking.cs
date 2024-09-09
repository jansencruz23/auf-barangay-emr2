using AUF.EMR2.Domain.Enums;
using AUF.EMR2.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Entities
{
    public class PregnancyTracking : BaseDomainEntity
    {
        public Guid HouseholdMemberId { get; set; }
        public HouseholdMember HouseholdMember { get; set; }
        public int Age { get; set; }
        public int Gravidity { get; set; }
        public int Parity { get; set; }
        public DateTime ExpectedDateOfDelivery { get; set; }
        public DateTime? FirstAntenatalCheckUp { get; set; }
        public DateTime? SecondAntenatalCheckUp { get; set; }
        public DateTime? ThirdAntenatalCheckUp { get; set; }
        public DateTime? MoreCheckUp { get; set; }
        public PregnancyOutcome? PregnancyOutcome { get; set; }
        public DateTime? PostnatalCheckUp24hrs { get; set; }
        public DateTime? PostnatalCheckUp7days { get; set; }
        public DateTime? LiveBirth { get; set; }
        public DateTime? MaternalDeath { get; set; }
        public DateTime? StillBirth { get; set; }
        public DateTime? EarlyNewbornDeath { get; set; }
    }
}
