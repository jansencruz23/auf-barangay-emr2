using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate.ValueObjects;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Persistence.Repositories;

public class PregnancyTrackingRepository : GenericRepository<PregnancyTracking, PregnancyTrackingId>, IPregnancyTrackingRepository
{
    private readonly EmrDbContext _dbContext;

    public PregnancyTrackingRepository(EmrDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PregnancyTracking> GetPregnancyTracking(PregnancyTrackingId id)
    {
        throw new NotImplementedException();
        //var pregnancyTracking = await _dbContext.PregnancyTrackings
        //    .AsNoTracking()
        //    .Include(p => p.HouseholdMember)
        //        .ThenInclude(m => m.Household)
        //    .Where(p => p.Status &&
        //        p.HouseholdMember.Status &&
        //        p.HouseholdMember.Household.Status)
        //    .FirstOrDefaultAsync(p => p.Id == id);

        //return pregnancyTracking;
    }

    public async Task<List<PregnancyTracking>> GetPregnancyTrackingList(string householdNo)
    {
        throw new NotImplementedException();
        //var pregnancyTrackingList = await _dbContext.PregnancyTrackings
        //    .AsNoTracking()
        //    .Include(p => p.HouseholdMember)
        //        .ThenInclude(m => m.Household)
        //    .Where(p => p.Status &&
        //        p.HouseholdMember.Household.HouseholdNo.Equals(householdNo) &&
        //        p.HouseholdMember.Household.Status &&
        //        p.HouseholdMember.Status)
        //    .ToListAsync();

        //return pregnancyTrackingList;
    }
}
