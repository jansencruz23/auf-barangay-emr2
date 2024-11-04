using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;

namespace AUF.EMR2.Persistence.Repositories.Common;

public abstract class HouseholdMemberDerivedRepository : GenericRepository<HouseholdMember, HouseholdMemberId>, IHouseholdMemberDerivedRepository
{
    private readonly EmrDbContext _dbContext;

    public HouseholdMemberDerivedRepository(EmrDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<HouseholdMember>> GetAllList(string householdNo)
    {
        throw new NotImplementedException();
        //var records = await _dbContext.HouseholdMembers
        //    .AsNoTracking()
        //    //.Include(m => m.Household)
        //    .Where(m => m.Household.Status &&
        //        m.Household.HouseholdNo.Equals(householdNo) &&
        //        m.Status)
        //    .ToListAsync();

        //return records;
    }

    public async Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate)
    {
        throw new NotImplementedException();
        //var records = await _dbContext.HouseholdMembers
        //    .AsNoTracking()
        //    .Include(m => m.Household)
        //    .Where(m => m.Household.Status &&
        //        m.Household.HouseholdNo.Equals(householdNo) &&
        //        m.Status &&
        //        m.Birthday >= startDate &&
        //        m.Birthday <= DateTime.Today)
        //    .ToListAsync();

        //return records;
    }

    public async Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
        //var records = await _dbContext.HouseholdMembers
        //    .AsNoTracking()
        //    .Include(m => m.Household)
        //    .Where(m => m.Household.Status &&
        //        m.Household.HouseholdNo.Equals(householdNo) &&
        //        m.Status &&
        //        m.Birthday >= startDate &&
        //        m.Birthday <= endDate)
        //    .ToListAsync();

        //return records;
    }

    public async Task<HouseholdMember> GetSingleMasterlistRecord(HouseholdMemberId id)
    {
        throw new NotImplementedException();
        //var record = await _dbContext.HouseholdMembers
        //    .AsNoTracking()
        //    .Include(q => q.Household)
        //    .FirstOrDefaultAsync(q => q.Id == id);

        //return record;
    }
}
