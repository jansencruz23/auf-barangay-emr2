using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;

public sealed class PregnancyTrackinggHhId : ValueObject
{
    public Guid Value { get; }

    private PregnancyTrackinggHhId(Guid value)
    {
        Value = value;  
    }

    public static PregnancyTrackinggHhId Create()
    {
        return new PregnancyTrackinggHhId(Guid.NewGuid());
    }

    public static PregnancyTrackinggHhId Create(Guid value)
    {
        return new PregnancyTrackinggHhId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
