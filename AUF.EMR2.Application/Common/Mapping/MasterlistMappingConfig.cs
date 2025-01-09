using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using Mapster;

namespace AUF.EMR2.Application.Common.Mapping;

public class MasterlistMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<HouseholdMember, MasterlistChildQueryResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.HouseholdId, src => src.HouseholdId.Value);

        config.NewConfig<HouseholdMember, MasterlistAdultQueryResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.HouseholdId, src => src.HouseholdId.Value);
    }
}
