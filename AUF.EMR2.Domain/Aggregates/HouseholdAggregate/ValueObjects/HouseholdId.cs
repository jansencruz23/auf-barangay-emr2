using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;

public sealed class HouseholdId : ValueObject
{
    public Guid Value { get; }

    private HouseholdId(Guid value)
    {
        Value = value;
    }

    public static HouseholdId Create(Guid value)
    {
        return new HouseholdId(value);
    }

    public static HouseholdId Create()
    {
        return new HouseholdId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
