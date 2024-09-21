using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;

public sealed class PregnancyTrackingHhId : ValueObject
{
    public Guid Value { get; }

    private PregnancyTrackingHhId(Guid value)
    {
        Value = value;  
    }

    public static PregnancyTrackingHhId Create()
    {
        return new PregnancyTrackingHhId(Guid.NewGuid());
    }

    public static PregnancyTrackingHhId Create(Guid value)
    {
        return new PregnancyTrackingHhId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
