using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;

public sealed class Philhealth : ValueObject
{
    public bool IsHeadPhilhealthMember { get; }
    public string? PhilhealthNo { get; }
    public string? Category { get; }

    private Philhealth(
        bool isHeadPhilhealthMember,
        string? philhealthNo,
        string? category)
    {
        IsHeadPhilhealthMember = isHeadPhilhealthMember;
        PhilhealthNo = philhealthNo;
        Category = category;
    }

    public static Philhealth Create(
        bool isHeadPhilhealthMember,
        string? philhealthNo,
        string? category)
    {
        return new Philhealth(isHeadPhilhealthMember, philhealthNo, category);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsHeadPhilhealthMember;
        yield return PhilhealthNo!;
        yield return Category!;
    }

    private Philhealth() { }
}
