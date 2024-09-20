using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Models.Pagination;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Abstraction.Persistence
{
    public interface IHouseholdMemberRepository : IGenericRepository<HouseholdMember>
    {
        Task<List<HouseholdMember>> GetHouseholdMemberList(string householdNo);
        Task<HouseholdMember> GetHouseholdMember(Guid id);
        Task<List<HouseholdMember>> GetWraHouseholdMemberList(string householdNo);
        Task<bool> IsWraMember(Guid id);
    }
}
