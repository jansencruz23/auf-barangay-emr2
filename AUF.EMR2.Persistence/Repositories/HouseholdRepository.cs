using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Application.Models.Pagination;
using AUF.EMR2.Domain.Models;
using AUF.EMR2.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace AUF.EMR2.Persistence.Repositories
{
    public class HouseholdRepository : GenericRepository<Household>, IHouseholdRepository
    {
        private readonly EmrDbContext _dbContext;

        public HouseholdRepository(EmrDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetFullAddress(string householdNo)
        {
            var address = await _dbContext.Households
                .AsNoTracking()
                .Where(q => q.Status && q.HouseholdNo.Equals(householdNo))
                .Select(q => $"{q.HouseNoAndStreet} {q.Barangay}, {q.City}, {q.Province}")
                .FirstOrDefaultAsync();

            return address;
        }

        public async Task<Household> GetHousehold(int id)
        {
            var household = await _dbContext.Households
                .AsNoTracking()
                .Include(q => q.HouseholdMembers.Where(w => w.Status))
                .Where(q => q.Status)
                .FirstOrDefaultAsync(q => q.Id == id);

            return household;
        }

        public async Task<Household> GetHouseholdByHouseholdNo(string householdNo)
        {
            var household = await _dbContext.Households
                .AsNoTracking()
                .Include(q => q.HouseholdMembers.Where(w => w.Status))
                .Where(q => q.Status)
                .FirstOrDefaultAsync(q => q.HouseholdNo.Equals(householdNo));

            return household;
        }

        public async Task<IPagedList<Household>> GetHouseholdList(RequestParams requestParams, string query = "")
        {
            var householdsQuery = _dbContext.Households
                .AsNoTracking()
                .Include(q => q.HouseholdMembers.Where(w => w.Status))
                .Where(q => q.Status);

            if (!string.IsNullOrWhiteSpace(query))
            {
                householdsQuery = householdsQuery.Where(q =>
                    q.LastName.Contains(query) ||
                    q.FirstName.Contains(query) ||
                    (q.FirstName + " " + q.LastName).Contains(query) ||
                    q.HouseholdNo.Contains(query) ||
                    q.HouseholdMembers.Any(w =>
                        w.LastName.Contains(query) ||
                        w.FirstName.Contains(query) && w.Status));
            }

            var households = await householdsQuery
                .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);

            return households;
        }
    }
}
