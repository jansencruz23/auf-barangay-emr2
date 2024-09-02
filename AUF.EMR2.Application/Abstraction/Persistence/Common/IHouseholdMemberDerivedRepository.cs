using AUF.EMR2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Abstraction.Persistence.Common
{
    public interface IHouseholdMemberDerivedRepository : IGenericRepository<HouseholdMember>
    {
        Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate);
        Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate, DateTime endDate);
        Task<List<HouseholdMember>> GetAllList(string householdNo);
        Task<HouseholdMember> GetSingleMasterlistRecord(int id);
    }
}
