using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Models.Pagination;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using X.PagedList;

namespace AUF.EMR2.Application.Abstraction.Persistence;

public interface IHouseholdRepository : IGenericRepository<Household, HouseholdId>
{
    Task<IPagedList<Household>> GetHouseholdList(RequestParams requestParams, string query = "");
    Task<Household> GetHousehold(HouseholdId id);
    Task<Household> GetHouseholdByHouseholdNo(string householdNo);
    Task<string> GetFullAddress(string householdNo);
    Task<bool> IsHouseholdNoAvailable(string householdNo);
}
