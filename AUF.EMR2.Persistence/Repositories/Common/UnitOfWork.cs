using AUF.EMR2.Application.Abstraction.Persistence;
using AUF.EMR2.Application.Abstraction.Persistence.Common;
using Microsoft.EntityFrameworkCore.Storage;
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
        private IDbContextTransaction _transaction;

        private IBarangayRepository _barangayRepository;
        private IHouseholdRepository _householdRepository;
        private IHouseholdMemberRepository _householdMemberRepository;
        private IMasterlistRepository _masterlistRepository;
        private IOralHealthRepository _oralHealthRepository;
        private IWraRepository _wraRepository;
        private IPregnancyTrackingRepository _pregnancyTrackingRepository;
        private IPregnancyTrackingHhRepository _pregnancyTrackingHhRepository;

        public UnitOfWork(EmrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IBarangayRepository BarangayRepository =>
            _barangayRepository ??= new BarangayRepository(_dbContext);

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

        public IPregnancyTrackingHhRepository PregnancyTrackingHhRepository =>
            _pregnancyTrackingHhRepository ??= new PregnancyTrackingHhRepository(_dbContext);

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
            return _transaction;
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
