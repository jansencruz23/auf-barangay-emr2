using AUF.EMR2.Application.Features.Households.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using Mapster;

namespace AUF.EMR2.Application.Common.Mapping;

public class HouseholdMemberMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<HouseholdMember, HouseholdQueryResponse>()
        //    .Map(dest => dest.Id, src => src.Id.Value);
    }
}
