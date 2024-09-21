using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;

public sealed class BarangayId : ValueObject
{
    public Guid Value { get; }

    private BarangayId(Guid value)
    {
        Value = value;
    }

    public static BarangayId Create()
    {
        return new BarangayId(Guid.NewGuid());
    }

    public static BarangayId Create(Guid value)
    {
        return new BarangayId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
