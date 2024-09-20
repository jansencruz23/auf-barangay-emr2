using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Enums;

namespace AUF.EMR2.Domain.Aggregates
{
    public class PregnancyTracking 
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
