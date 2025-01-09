using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;

namespace AUF.EMR2.Application.Abstraction.Persistence;

public interface IHouseholdMemberRepository : IGenericRepository<HouseholdMember, HouseholdMemberId>
{
    Task<List<HouseholdMember>> GetHouseholdMemberList(HouseholdId householdId);
    Task<List<HouseholdMember>> GetHouseholdMemberList(List<HouseholdId> householdIds);
    Task<HouseholdMember> GetHouseholdMember(HouseholdMemberId id);
    Task<List<HouseholdMember>> GetWraHouseholdMemberList(HouseholdId householdId);
    Task<bool> IsWraMember(HouseholdMemberId id);
    Task<List<HouseholdMember>> GetListQuery(HouseholdId householdId, DateTime startDate);
    Task<List<HouseholdMember>> GetListQuery(HouseholdId householdId, DateTime startDate, DateTime endDate);
}
