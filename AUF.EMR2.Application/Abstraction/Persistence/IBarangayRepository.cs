using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.BarangayAggregate;
using AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;

namespace AUF.EMR2.Application.Abstraction.Persistence;

public interface IBarangayRepository : IGenericRepository<Barangay, BarangayId>
{
    Task<Barangay> GetBarangay();
}
