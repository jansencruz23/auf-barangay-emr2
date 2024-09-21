using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Domain.Aggregates.BarangayAggregate;
using AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Persistence.Repositories;

public class BarangayRepository : GenericRepository<Barangay, BarangayId>, IBarangayRepository
{
    private readonly EmrDbContext _dbContext;

    public BarangayRepository(EmrDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Barangay> GetBarangay()
    {
        var barangay = await _dbContext.Barangays
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return barangay;
    }
}
