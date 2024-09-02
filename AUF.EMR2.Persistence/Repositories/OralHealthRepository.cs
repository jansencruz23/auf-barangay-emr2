using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Domain.Models;
using AUF.EMR2.Persistence.Repositories.Common;
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

        public Task<List<HouseholdMember>> GetPregnantHouseholdMembers(string householdNo, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
