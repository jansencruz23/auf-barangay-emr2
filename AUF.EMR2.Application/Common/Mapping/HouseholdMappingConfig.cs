using AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using Mapster;

namespace AUF.EMR2.Application.Common.Mapping;

public sealed class HouseholdMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Household, GetHouseholdListQueryResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
