using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Application.Constants;
using AUF.EMR2.Domain.Models;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Persistence.Repositories
{
    public class HouseholdMemberRepository : GenericRepository<HouseholdMember>, IHouseholdMemberRepository
    {
        private readonly EmrDbContext _dbContext;

        public HouseholdMemberRepository(EmrDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HouseholdMember> GetHouseholdMember(int id)
        {
            var householdMember = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status && m.Status)
                .FirstOrDefaultAsync(m => m.Id == id);

            return householdMember;
        }

        public async Task<List<HouseholdMember>> GetHouseholdMemberList(string householdNo)
        {
            var householdMembers = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(q => q.Household)
                .Where(q => q.Household.Status && q.Household.HouseholdNo.Equals(householdNo) && q.Status)
                .OrderBy(q => q.RelationshipToHouseholdHead == 1 ? 0 :
                    q.RelationshipToHouseholdHead == 2 ? 1 :
                    q.RelationshipToHouseholdHead == 3 || q.RelationshipToHouseholdHead == 4 ? 2 : 3)
                .ThenBy(q => q.RelationshipToHouseholdHead == 3 || q.RelationshipToHouseholdHead == 4 ? q.Birthday : DateTime.MaxValue)
                .ToListAsync();

            return householdMembers;
        }

        public async Task<List<HouseholdMember>> GetWraHouseholdMemberList(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(WraAgeRange.WraStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(WraAgeRange.WraEnd);
                
            var WraMembers = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Status && m.Household.Status &&
                            m.Household.HouseholdNo.Equals(householdNo) &&
                            m.Sex.Equals('F') &&
                            m.Birthday >= startDate &&
                            m.Birthday <= endDate)
                .ToListAsync();

            return WraMembers;
        }
    }
}
