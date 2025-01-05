using AUF.EMR2.Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;

[NotMapped]
public sealed class HouseholdMemberId : ValueObject
{
    public Guid Value { get; }
    
    private HouseholdMemberId(Guid value)
    {
        Value = value;
    } 

    public static HouseholdMemberId Create(Guid value)
    {
        return new HouseholdMemberId(value);
    }

    public static HouseholdMemberId Create()
    {
        return new HouseholdMemberId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private HouseholdMemberId() { }
}
