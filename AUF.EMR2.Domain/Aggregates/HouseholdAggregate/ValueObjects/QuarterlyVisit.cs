using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;

public sealed class QuarterlyVisit : ValueObject
{
    public DateTime? FirstQtrVisit { get; }
    public DateTime? SecondQtrVisit { get; }
    public DateTime? ThirdQtrVisit { get; }
    public DateTime? FourthQtrVisit { get; }

    private QuarterlyVisit(
        DateTime? firstQtrVisit,
        DateTime? secondQtrVisit,
        DateTime? thirdQtrVisit,
        DateTime? fourthQtrVisit)
    {
        FirstQtrVisit = firstQtrVisit;
        SecondQtrVisit = secondQtrVisit;
        ThirdQtrVisit = thirdQtrVisit;
        FourthQtrVisit = fourthQtrVisit;
    }

    public static QuarterlyVisit Create(
        DateTime? firstQtrVisit,
        DateTime? secondQtrVisit,
        DateTime? thirdQtrVisit,
        DateTime? fourthQtrVisit)
    {
        return new QuarterlyVisit(
            firstQtrVisit,
            secondQtrVisit,
            thirdQtrVisit,
            fourthQtrVisit
        );
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstQtrVisit ?? DateTime.MinValue;
        yield return SecondQtrVisit ?? DateTime.MinValue;
        yield return ThirdQtrVisit ?? DateTime.MinValue;
        yield return FourthQtrVisit ?? DateTime.MinValue;
    }

    private QuarterlyVisit(){}
}
