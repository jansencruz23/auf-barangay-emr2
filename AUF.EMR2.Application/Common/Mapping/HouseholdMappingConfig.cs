using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using AUF.EMR2.Application.Features.Households.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using Mapster;
using MapsterMapper;

namespace AUF.EMR2.Application.Common.Mapping;

public sealed class HouseholdMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Household, HouseholdQueryResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
