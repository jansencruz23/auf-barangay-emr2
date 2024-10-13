using AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate;
using Mapster;

namespace AUF.EMR2.Application.Common.Mapping;

public class PregnancyTrackingHhMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PregnancyTrackingHh, GetPregnancyTrackingHhQueryResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.HouseholdId, src => src.HouseholdId.Value);
    }
}
