using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Persistence.Repositories.Common
{
    public abstract class HouseholdMemberDerivedRepository : GenericRepository<HouseholdMember>, IHouseholdMemberDerivedRepository
    {
        private readonly EmrDbContext _dbContext;

        public HouseholdMemberDerivedRepository(EmrDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HouseholdMember>> GetAllList(string householdNo)
        {
            var records = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status &&
                    m.Household.HouseholdNo.Equals(householdNo) &&
                    m.Status)
                .ToListAsync();

            return records;
        }

        public async Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate)
        {
            var records = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status &&
                    m.Household.HouseholdNo.Equals(householdNo) &&
                    m.Status &&
                    m.Birthday >= startDate &&
                    m.Birthday <= DateTime.Today)
                .ToListAsync();

            return records;
        }

        public async Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate, DateTime endDate)
        {
            var records = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status &&
                    m.Household.HouseholdNo.Equals(householdNo) &&
                    m.Status &&
                    m.Birthday >= startDate &&
                    m.Birthday <= endDate)
                .ToListAsync();

            return records;
        }

        public async Task<HouseholdMember> GetSingleMasterlistRecord(int id)
        {
            var record = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(q => q.Household)
                .FirstOrDefaultAsync(q => q.Id == id);

            return record;
        }
    }
}
