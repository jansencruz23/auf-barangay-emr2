using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Application.Constants;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Persistence.Repositories
{
    public class HouseholdMemberRepository : GenericRepository<HouseholdMember, HouseholdMemberId>, IHouseholdMemberRepository
    {
        private readonly EmrDbContext _dbContext;

        public HouseholdMemberRepository(EmrDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<HouseholdMember> GetHouseholdMember(HouseholdMemberId id)
        {
            throw new NotImplementedException();
            //var householdMember = await _dbContext.HouseholdMembers
            //    .AsNoTracking()
            //    .Include(m => m.Household)
            //    .Where(m => m.Household.Status && m.Status)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            //return householdMember;
        }

        public async Task<List<HouseholdMember>> GetHouseholdMemberList(string householdNo)
        {
            throw new NotImplementedException();
            //var householdMembers = await _dbContext.HouseholdMembers
            //    .AsNoTracking()
            //    .Include(q => q.Household)
            //    .Where(q => q.Household.Status && q.Household.HouseholdNo.Equals(householdNo) && q.Status)
            //    .OrderBy(q => q.RelationshipToHouseholdHead == 1 ? 0 :
            //        q.RelationshipToHouseholdHead == 2 ? 1 :
            //        q.RelationshipToHouseholdHead == 3 || q.RelationshipToHouseholdHead == 4 ? 2 : 3)
            //    .ThenBy(q => q.RelationshipToHouseholdHead == 3 || q.RelationshipToHouseholdHead == 4 ? q.Birthday : DateTime.MaxValue)
            //    .ToListAsync();

            //return householdMembers;
        }

        public async Task<List<HouseholdMember>> GetWraHouseholdMemberList(string householdNo)
        {
            throw new NotImplementedException();
            //var startDate = DateTime.Today.AddYears(WraAgeRange.WraStart).AddDays(1);
            //var endDate = DateTime.Today.AddYears(WraAgeRange.WraEnd);
                
            //var wraMembers = await _dbContext.HouseholdMembers
            //    .AsNoTracking()
            //    .Include(m => m.Household)
            //    .Where(m => m.Status && m.Household.Status &&
            //                m.Household.HouseholdNo.Equals(householdNo) &&
            //                m.Sex.Equals('F') &&
            //                m.Birthday >= startDate &&
            //                m.Birthday <= endDate)
            //    .ToListAsync();

            //return wraMembers;
        }

        public Task<bool> IsWraMember(HouseholdMemberId id)
        {
            throw new NotImplementedException();
            //var startDate = DateTime.Today.AddYears(WraAgeRange.WraStart).AddDays(1);
            //var endDate = DateTime.Today.AddYears(WraAgeRange.WraEnd);

            //var isMember = await _dbContext.HouseholdMembers
            //    .AsNoTracking()
            //    .Include(m => m.Household)
            //    .Where(m => m.Status &&
            //                m.Household.Status &&
            //                m.Sex.Equals('F') &&
            //                m.Birthday >= startDate &&
            //                m.Birthday <= endDate)
            //    .FirstOrDefaultAsync(q => q.Id == id);

            //return isMember != null;
        }
    }
}
