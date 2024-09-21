using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate.Enums;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate;

public class PregnancyTracking : AggregateRoot<PregnancyTrackingId>
{
    public HouseholdMemberId HouseholdMemberId { get; private set; } = null!;

    public int Age { get; private set; }
    public int Gravidity { get; private set; }
    public int Parity { get; private set; }
    public DateTime ExpectedDateOfDelivery { get; private set; }
    public DateTime? FirstAntenatalCheckUp { get; private set; }
    public DateTime? SecondAntenatalCheckUp { get; private set; }
    public DateTime? ThirdAntenatalCheckUp { get; private set; }
    public DateTime? MoreCheckUp { get; private set; }
    public PregnancyOutcome? PregnancyOutcome { get; private set; }
    public DateTime? PostnatalCheckUp24hrs { get; private set; }
    public DateTime? PostnatalCheckUp7days { get; private set; }
    public DateTime? LiveBirth { get; private set; }
    public DateTime? MaternalDeath { get; private set; }
    public DateTime? StillBirth { get; private set; }
    public DateTime? EarlyNewbornDeath { get; private set; }

    private PregnancyTracking(
        PregnancyTrackingId pregnancyTrackingId,
        HouseholdMemberId householdMemberId,
        int age,
        int gravidity,
        int parity,
        DateTime expectedDateOfDelivery,
        DateTime? firstAntenatalCheckUp,
        DateTime? secondAntenatalCheckUp,
        DateTime? thirdAntenatalCheckUp,
        DateTime? moreCheckUp,
        PregnancyOutcome? pregnancyOutcome,
        DateTime? postnatalCheckUp24hrs,
        DateTime? postnatalCheckUp7days,
        DateTime? liveBirth,
        DateTime? maternalDeath,
        DateTime? stillBirth,
        DateTime? earlyNewbornDeath)
        : base(pregnancyTrackingId)
    {
        HouseholdMemberId = householdMemberId;
        Age = age;
        Gravidity = gravidity;
        Parity = parity;
        ExpectedDateOfDelivery = expectedDateOfDelivery;
        FirstAntenatalCheckUp = firstAntenatalCheckUp;
        SecondAntenatalCheckUp = secondAntenatalCheckUp;
        ThirdAntenatalCheckUp = thirdAntenatalCheckUp;
        MoreCheckUp = moreCheckUp;
        PregnancyOutcome = pregnancyOutcome;
        PostnatalCheckUp24hrs = postnatalCheckUp24hrs;
        PostnatalCheckUp7days = postnatalCheckUp7days;
        LiveBirth = liveBirth;
        MaternalDeath = maternalDeath;
        StillBirth = stillBirth;
        EarlyNewbornDeath = earlyNewbornDeath;
    }

    public static PregnancyTracking Create(
        HouseholdMemberId householdMemberId,
        int age,
        int gravidity,
        int parity,
        DateTime expectedDateOfDelivery,
        DateTime? firstAntenatalCheckUp,
        DateTime? secondAntenatalCheckUp,
        DateTime? thirdAntenatalCheckUp,
        DateTime? moreCheckUp,
        PregnancyOutcome? pregnancyOutcome,
        DateTime? postnatalCheckUp24hrs,
        DateTime? postnatalCheckUp7days,
        DateTime? liveBirth,
        DateTime? maternalDeath,
        DateTime? stillBirth,
        DateTime? earlyNewbornDeath)
    {
        return new PregnancyTracking(
            pregnancyTrackingId: PregnancyTrackingId.Create(),
            householdMemberId: householdMemberId,
            age: age,
            gravidity: gravidity,
            parity: parity,
            expectedDateOfDelivery: expectedDateOfDelivery,
            firstAntenatalCheckUp: firstAntenatalCheckUp,
            secondAntenatalCheckUp: secondAntenatalCheckUp,
            thirdAntenatalCheckUp: thirdAntenatalCheckUp,
            moreCheckUp: moreCheckUp,
            pregnancyOutcome: pregnancyOutcome,
            postnatalCheckUp24hrs: postnatalCheckUp24hrs,
            postnatalCheckUp7days: postnatalCheckUp7days,
            liveBirth: liveBirth,
            maternalDeath: maternalDeath,
            stillBirth: stillBirth,
            earlyNewbornDeath: earlyNewbornDeath);
    }

    private PregnancyTracking() { }
}
