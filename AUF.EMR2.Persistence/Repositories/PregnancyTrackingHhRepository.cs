using AUF.EMR2.Application.Abstraction.Persistence;
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
    public class PregnancyTrackingHhRepository : GenericRepository<PregnancyTrackingHh>, IPregnancyTrackingHhRepository
    {
        private readonly EmrDbContext _dbContext;

        public PregnancyTrackingHhRepository(EmrDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PregnancyTrackingHh> GetPregnancyTrackingHh(string householdNo)
        {
            var pregnancyTrackingHh = await _dbContext.PregnancyTrackingHhs
                .AsNoTracking()
                .Include(p => p.Household)
                .FirstOrDefaultAsync(p => p.Household.HouseholdNo.Equals(householdNo));

            return pregnancyTrackingHh;
        }
    }
}
