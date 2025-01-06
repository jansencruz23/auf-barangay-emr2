using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Application.Common.Constants;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Persistence.Repositories;

public class HouseholdMemberRepository : GenericRepository<HouseholdMember, HouseholdMemberId>, IHouseholdMemberRepository
{
    private readonly EmrDbContext _dbContext;

    public HouseholdMemberRepository(EmrDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HouseholdMember> GetHouseholdMember(HouseholdMemberId id)
    {
        var householdMember = await _dbContext.HouseholdMembers
            .AsNoTracking()
            .Where(m => m.Status)
            .FirstOrDefaultAsync(m => m.Id == id);

        return householdMember!;
    }

    public async Task<List<HouseholdMember>> GetHouseholdMemberList(HouseholdId householdId)
    {
        var householdMembers = await _dbContext.HouseholdMembers
            .AsNoTracking()
            .Where(q => q.HouseholdId == householdId && q.Status)
            .OrderBy(q => q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Head
                ? 0
                : q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Spouse
                    ? 1
                    : q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Son
                    || q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Daughter
                        ? 2
                        : 3)
            .ThenBy(q => q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Son
                || q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Daughter
                    ? q.Birthday
                    : DateTime.MaxValue)
            .ToListAsync();

        return householdMembers;
    }

    public async Task<List<HouseholdMember>> GetHouseholdMemberList(List<HouseholdId> householdIds)
    {
        var householdMembers = await _dbContext.HouseholdMembers
            .AsNoTracking()
            .Where(q => householdIds.Contains(q.HouseholdId) && q.Status)
            .OrderBy(q => q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Head
                ? 0
                : q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Spouse
                    ? 1
                    : q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Son
                    || q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Daughter
                        ? 2
                        : 3)
            .ThenBy(q => q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Son
                || q.RelationshipToHouseholdHead == RelationshipToHouseholdHead.Daughter
                    ? q.Birthday
                    : DateTime.MaxValue)
            .ToListAsync();

        return householdMembers;
    }

    public async Task<List<HouseholdMember>> GetWraHouseholdMemberList(HouseholdId householdId)
    {
        var startDate = DateTime.Today.AddYears(WraAgeRange.WraStart).AddDays(1);
        var endDate = DateTime.Today.AddYears(WraAgeRange.WraEnd);

        var wraMembers = await _dbContext.HouseholdMembers
            .AsNoTracking()
            .Where(m => m.Status &&
                        m.HouseholdId == householdId &&
                        m.Sex == Sex.Female &&
                        m.Birthday >= startDate &&
                        m.Birthday <= endDate)
            .ToListAsync();

        return wraMembers;
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
