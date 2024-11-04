using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;

namespace AUF.EMR2.Application.Abstraction.Persistence.Common;

public interface IHouseholdMemberDerivedRepository : IGenericRepository<HouseholdMember, HouseholdMemberId>
{
    Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate);
    Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate, DateTime endDate);
    Task<List<HouseholdMember>> GetAllList(string householdNo);
    Task<HouseholdMember> GetSingleMasterlistRecord(HouseholdMemberId id);
}
