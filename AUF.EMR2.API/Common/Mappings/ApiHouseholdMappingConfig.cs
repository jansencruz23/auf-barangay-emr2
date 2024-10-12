using AUF.EMR2.Application.DTOs.Household.ValueObjectDtos;
using Mapster;
using AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;
using AUF.EMR2.Application.Features.Households.Common;
using AUF.EMR2.Contracts.Households.Request;
using AUF.EMR2.Contracts.Households.Response;
using AUF.EMR2.Application.Features.Households.Queries.Common;

namespace AUF.EMR2.API.Common.Mappings;

public class ApiHouseholdMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateHouseholdCommand, CreateHouseholdRequest>();
        config.NewConfig<HouseholdQueryResponse, HouseholdResponse>();

        config.NewConfig<HouseAddressData, HouseAddressDto>();
        config.NewConfig<PhilhealthData, PhilhealthDto>();
    }
}
