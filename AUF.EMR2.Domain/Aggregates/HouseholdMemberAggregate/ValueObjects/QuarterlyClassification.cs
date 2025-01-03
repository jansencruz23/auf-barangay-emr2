using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;

public sealed class QuarterlyClassification : ValueObject
{
    public string? FirstQtrClassification { get; }
    public string? SecondQtrClassification { get; }
    public string? ThirdQtrClassification { get; }
    public string? FourthQtrClassification { get; }

    private QuarterlyClassification(
        string? firstQtrClassification,
        string? secondQtrClassification,
        string? thirdQtrClassification,
        string? fourthQtrClassification)
    {
        FirstQtrClassification = firstQtrClassification;
        SecondQtrClassification = secondQtrClassification;
        ThirdQtrClassification = thirdQtrClassification;
        FourthQtrClassification = fourthQtrClassification;
    }

    public static QuarterlyClassification Create(
        string? firstQtrClassification,
        string? secondQtrClassification,
        string? thirdQtrClassification,
        string? fourthQtrClassification)
    {
        return new QuarterlyClassification(
            firstQtrClassification,
            secondQtrClassification,
            thirdQtrClassification,
            fourthQtrClassification
        );
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstQtrClassification ?? string.Empty;
        yield return SecondQtrClassification ?? string.Empty;
        yield return ThirdQtrClassification ?? string.Empty;
        yield return FourthQtrClassification ?? string.Empty;
    }
}