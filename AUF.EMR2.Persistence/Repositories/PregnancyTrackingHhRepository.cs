using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
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

    public async Task<PregnancyTrackingHh> GetPregnancyTrackingHh(HouseholdId householdId)
    {
        var pregnancyTrackingHh = await _dbContext.PregnancyTrackingHhs
            .AsNoTracking()
            .FirstOrDefaultAsync(pregTrackHh => pregTrackHh.HouseholdId == householdId);

        return pregnancyTrackingHh!;
    }

    public async Task<PregnancyTrackingHh> GetPregnancyTrackingHh(PregnancyTrackingHhId id)
    {
        var pregnancyTrackingHh = await _dbContext.PregnancyTrackingHhs
            .AsNoTracking()
            .FirstOrDefaultAsync(pregTrackHh => pregTrackHh.Id == id);

        return pregnancyTrackingHh!;
    }
}
