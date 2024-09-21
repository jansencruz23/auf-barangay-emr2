using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.WomanOfReproductiveAgeAggregate.ValueObjects;

public sealed class WomanOfReproductiveAgeId : ValueObject
{
    public Guid Value { get; }

    private WomanOfReproductiveAgeId(Guid value)
    {
        Value = value;
    }

    public static WomanOfReproductiveAgeId Create()
    {
        return new WomanOfReproductiveAgeId(Guid.NewGuid());
    }

    public static WomanOfReproductiveAgeId Create(Guid value)
    {
        return new WomanOfReproductiveAgeId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private WomanOfReproductiveAgeId() { }
}
