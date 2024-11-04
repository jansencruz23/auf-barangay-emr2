using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.ValueObjects;

namespace AUF.EMR2.Application.Abstraction.Persistence;

public interface IPregnancyTrackingHhRepository : IGenericRepository<PregnancyTrackingHh, PregnancyTrackingHhId>
{
    Task<PregnancyTrackingHh> GetPregnancyTrackingHh(HouseholdId householdId);
    Task<PregnancyTrackingHh> GetPregnancyTrackingHh(PregnancyTrackingHhId id);
}
