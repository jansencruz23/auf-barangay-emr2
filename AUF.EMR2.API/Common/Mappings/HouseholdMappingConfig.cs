using AUF.EMR2.Application.DTOs.Household.ValueObjectDtos;
using Mapster;
using AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;
using AUF.EMR2.Application.Features.Households.Common;
using AUF.EMR2.Contracts.Households.Request;

namespace AUF.EMR2.API.Common.Mappings;

public class HouseholdMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateHouseholdCommand, CreateHouseholdRequest>();

        config.NewConfig<HouseAddressRequest, HouseAddressDto>();
        config.NewConfig<PhilhealthRequest, PhilhealthDto>();
    }
}
