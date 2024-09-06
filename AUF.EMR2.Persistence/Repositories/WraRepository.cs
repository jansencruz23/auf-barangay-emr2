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
    public class WraRepository : GenericRepository<WomanOfReproductiveAge>, IWraRepository
    {
        private readonly EmrDbContext _dbContext;

        public WraRepository(EmrDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WomanOfReproductiveAge> GetWra(int id)
        {
            var wra = await _dbContext.WomenOfReproductiveAge
                .AsNoTracking()
                .Include(w => w.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(w => w.Status)
                .FirstOrDefaultAsync(w => w.Id == id);

            return wra;
        }

        public async Task<List<WomanOfReproductiveAge>> GetWraList(string householdNo)
        {
            var wraList = await _dbContext.WomenOfReproductiveAge
                .AsNoTracking()
                .Include(w => w.HouseholdMember)
                    .ThenInclude(m => m.Household)
                .Where(w => w.HouseholdMember.Household.HouseholdNo.Equals(householdNo) && w.Status)
                .ToListAsync();

            return wraList;
        }
    }
}
