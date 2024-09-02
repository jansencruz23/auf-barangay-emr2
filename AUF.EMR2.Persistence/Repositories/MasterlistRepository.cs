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
    public class MasterlistRepository : GenericRepository<HouseholdMember>, IMasterlistRepository
    {
        private readonly EmrDbContext _dbContext;

        public MasterlistRepository(EmrDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HouseholdMember>> GetAllList(string householdNo)
        {
            var masterlist = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status &&
                    m.Household.HouseholdNo.Equals(householdNo) &&
                    m.Status)
                .ToListAsync();

            return masterlist;
        }

        public async Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate)
        {
            var masterlist = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status &&
                    m.Household.HouseholdNo.Equals(householdNo) &&
                    m.Status &&
                    m.Birthday >= startDate &&
                    m.Birthday <= DateTime.Today)
                .ToListAsync();

            return masterlist;
        }

        public async Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate, DateTime endDate)
        {
            var masterlist = await _dbContext.HouseholdMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status &&
                    m.Household.HouseholdNo.Equals(householdNo) &&
                    m.Status &&
                    m.Birthday >= startDate &&
                    m.Birthday <= endDate)
                .ToListAsync();

            return masterlist;
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
