using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Domain.Aggregates.WomanOfReproductiveAgeAggregate;
using AUF.EMR2.Domain.Aggregates.WomanOfReproductiveAgeAggregate.ValueObjects;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Persistence.Repositories
{
    public class WraRepository : GenericRepository<WomanOfReproductiveAge, WomanOfReproductiveAgeId>, IWraRepository
    {
        private readonly EmrDbContext _dbContext;

        public WraRepository(EmrDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WomanOfReproductiveAge> GetWra(WomanOfReproductiveAgeId id)
        {
            throw new NotImplementedException();
            //var wra = await _dbContext.WomenOfReproductiveAge
            //    .AsNoTracking()
            //    .Include(w => w.HouseholdMember)
            //        .ThenInclude(m => m.Household)
            //    .Where(w => w.Status)
            //    .FirstOrDefaultAsync(w => w.Id == id);

            //return wra;
        }

        public async Task<List<WomanOfReproductiveAge>> GetWraList(string householdNo)
        {
            throw new NotImplementedException();
            //var wraList = await _dbContext.WomenOfReproductiveAge
            //    .AsNoTracking()
            //    .Include(w => w.HouseholdMember)
            //        .ThenInclude(m => m.Household)
            //    .Where(w => w.HouseholdMember.Household.HouseholdNo.Equals(householdNo) && w.Status)
            //    .ToListAsync();

            //return wraList;
        }
    }
}
