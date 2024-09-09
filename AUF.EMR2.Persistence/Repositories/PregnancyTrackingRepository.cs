using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Domain.Entities;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Persistence.Repositories
{
    public class PregnancyTrackingRepository : GenericRepository<PregnancyTracking>, IPregnancyTrackingRepository
    {
        private readonly EmrDbContext _dbContext;

        public PregnancyTrackingRepository(EmrDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PregnancyTracking> GetPregnancyTracking(int id)
        {
            var pregnancyTracking = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Status &&
                    p.HouseholdMember.Household.Status)
                .FirstOrDefaultAsync(p => p.Id == id);

            return pregnancyTracking;
        }

        public async Task<List<PregnancyTracking>> GetPregnancyTrackingList(string householdNo)
        {
            var pregnancyTrackingList = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Household.HouseholdNo.Equals(householdNo) &&
                    p.HouseholdMember.Household.Status &&
                    p.HouseholdMember.Status)
                .ToListAsync();

            return pregnancyTrackingList;
        }
    }
}
