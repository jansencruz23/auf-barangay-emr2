using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Abstraction.Persistence.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IBarangayRepository BarangayRepository { get; }
        IHouseholdRepository HouseholdRepository { get; }
        IHouseholdMemberRepository HouseholdMemberRepository { get; }
        IMasterlistRepository MasterlistRepository { get; }
        IOralHealthRepository OralHealthRepository { get; }
        IWraRepository WraRepository{ get; }
        IPregnancyTrackingRepository PregnancyTrackingRepository { get; }
        IPregnancyTrackingHhRepository PregnancyTrackingHhRepository { get; }
        Task SaveAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
