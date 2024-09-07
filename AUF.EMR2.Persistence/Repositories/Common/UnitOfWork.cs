using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Application.Abstraction.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmrDbContext _dbContext;

        private IHouseholdRepository _householdRepository;
        private IHouseholdMemberRepository _householdMemberRepository;
        private IMasterlistRepository _masterlistRepository;
        private IOralHealthRepository _oralHealthRepository;
        private IWraRepository _wraRepository;
        private IPregnancyTrackingRepository _pregnancyTrackingRepository;

        public UnitOfWork(EmrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IHouseholdRepository HouseholdRepository =>
            _householdRepository ??= new HouseholdRepository(_dbContext);

        public IHouseholdMemberRepository HouseholdMemberRepository =>
            _householdMemberRepository ??= new HouseholdMemberRepository(_dbContext);

        public IMasterlistRepository MasterlistRepository =>
            _masterlistRepository ??= new MasterlistRepository(_dbContext);

        public IOralHealthRepository OralHealthRepository =>
            _oralHealthRepository ??= new OralHealthRepository(_dbContext);

        public IWraRepository WraRepository =>
            _wraRepository ??= new WraRepository(_dbContext);

        public IPregnancyTrackingRepository PregnancyTrackingRepository =>
            _pregnancyTrackingRepository ??= new PregnancyTrackingRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
