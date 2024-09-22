using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.DTOs.Household.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using Mapster;

namespace AUF.EMR2.Application.Common.Mapping;

public class HouseholdMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Household, HouseholdDto>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Household, HouseholdOnlyDto>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Household, CreateHouseholdDto>();
        config.NewConfig<Household, UpdateHouseholdDto>();

        config.NewConfig<HouseAddressDto, HouseAddress>();
        config.NewConfig<Philhealth, PhilhealthDto>();
    }
}
