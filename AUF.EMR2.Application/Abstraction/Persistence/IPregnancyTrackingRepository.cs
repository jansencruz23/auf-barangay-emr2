using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate.ValueObjects;

namespace AUF.EMR2.Application.Abstraction.Persistence;

public interface IPregnancyTrackingRepository : IGenericRepository<PregnancyTracking, PregnancyTrackingId>
{
    Task<List<PregnancyTracking>> GetPregnancyTrackingList(string householdNo);
    Task<PregnancyTracking> GetPregnancyTracking(PregnancyTrackingId id);
}
