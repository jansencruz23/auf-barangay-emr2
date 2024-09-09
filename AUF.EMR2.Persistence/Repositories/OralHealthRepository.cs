using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Domain.Entities;
using AUF.EMR2.Domain.Enums;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Persistence.Repositories
{
    public class OralHealthRepository : HouseholdMemberDerivedRepository, IOralHealthRepository
    {
        private readonly EmrDbContext _dbContext;

        public OralHealthRepository(EmrDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HouseholdMember>> GetPregnantHouseholdMembers(string householdNo, DateTime startDate, DateTime endDate)
        {
            var pregnantMembers = await _dbContext.PregnancyTrackings
                .AsNoTracking()
                .Include(p => p.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(p => p.Status &&
                    p.HouseholdMember.Household.HouseholdNo.Equals(householdNo) &&
                    p.HouseholdMember.Household.Status && 
                    p.HouseholdMember.Status)
                .Where(p => p.PregnancyOutcome == null || p.PregnancyOutcome == PregnancyOutcome.OngoingPregnancy)
                .Where(p => p.HouseholdMember.Birthday >= startDate && p.HouseholdMember.Birthday <= endDate)
                .Select(p => p.HouseholdMember)
                .ToListAsync();

            return pregnantMembers;
        }
    }
}
