using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;

namespace AUF.EMR2.Application.Abstraction.Persistence;

public interface IHouseholdMemberRepository : IGenericRepository<HouseholdMember, HouseholdMemberId>
{
    Task<List<HouseholdMember>> GetHouseholdMemberList(Guid householdId);
    Task<HouseholdMember> GetHouseholdMember(HouseholdMemberId id);
    Task<List<HouseholdMember>> GetWraHouseholdMemberList(string householdNo);
    Task<bool> IsWraMember(HouseholdMemberId id);
}
