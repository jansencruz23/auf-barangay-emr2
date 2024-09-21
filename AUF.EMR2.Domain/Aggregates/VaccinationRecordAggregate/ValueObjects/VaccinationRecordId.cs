using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.VaccinationRecordAggregate.ValueObjects;

public sealed class VaccinationRecordId : ValueObject
{
    public Guid Value { get; }

    private VaccinationRecordId(Guid value)
    {
        Value = value;
    }

    public static VaccinationRecordId Create()
    {
        return new VaccinationRecordId(Guid.NewGuid());
    }

    public static VaccinationRecordId Create(Guid value)
    {
        return new VaccinationRecordId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
