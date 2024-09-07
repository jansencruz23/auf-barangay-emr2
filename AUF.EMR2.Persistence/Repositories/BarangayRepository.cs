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
    public class BarangayRepository : GenericRepository<Barangay>, IBarangayRepository
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
}
