using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;

public class HouseholdMemberId : ValueObject
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
        throw new NotImplementedException();
    }
}
