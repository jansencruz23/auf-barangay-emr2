using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate.ValueObjects;

public sealed class PregnancyTrackingId : ValueObject
{
    public Guid Value { get; }

    private PregnancyTrackingId(Guid value)
    {
        Value = value;
    }

    public static PregnancyTrackingId Create()
    {
        return new PregnancyTrackingId(Guid.NewGuid());
    }

    public static PregnancyTrackingId Create(Guid value)
    {
        return new PregnancyTrackingId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
