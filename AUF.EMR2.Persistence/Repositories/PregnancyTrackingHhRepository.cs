using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.ValueObjects;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Persistence.Repositories;

public class PregnancyTrackingHhRepository : GenericRepository<PregnancyTrackingHh, PregnancyTrackingHhId>, IPregnancyTrackingHhRepository
{
    private readonly EmrDbContext _dbContext;

    public PregnancyTrackingHhRepository(EmrDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PregnancyTrackingHh> GetPregnancyTrackingHh(string householdNo)
    {
        throw new NotImplementedException();
        //var pregnancyTrackingHh = await _dbContext.PregnancyTrackingHhs
        //    .AsNoTracking()
        //    .Include(q => q.Household)
        //    .Include(q => q.Barangay)
        //    .FirstOrDefaultAsync(q => q.Household.HouseholdNo.Equals(householdNo));

        //return pregnancyTrackingHh;
    }

    public async Task<PregnancyTrackingHh> GetPregnancyTrackingHh(PregnancyTrackingHhId id)
    {
        throw new NotImplementedException();
        //var pregnancyTrackingHh = await _dbContext.PregnancyTrackingHhs
        //    .AsNoTracking()
        //    .Include(q => q.Household)
        //    .Include(q => q.Barangay)
        //    .FirstOrDefaultAsync(q => q.Id == id);

        //return pregnancyTrackingHh;
    }
}
