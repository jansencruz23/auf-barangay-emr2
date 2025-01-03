using Mapster;
using AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;
using AUF.EMR2.Application.Features.Households.Common;
using AUF.EMR2.Contracts.Households.Requests;
using AUF.EMR2.Contracts.Households.Responses;
using AUF.EMR2.Application.Features.Households.Queries.Common;
using AUF.EMR2.Contracts.Households.Common.ValueObjectDtos;

namespace AUF.EMR2.API.Common.Mappings;

public class HouseholdApiMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateHouseholdCommand, CreateHouseholdRequest>();
        config.NewConfig<HouseholdQueryResponse, HouseholdResponse>();

        config.NewConfig<HouseAddressData, HouseAddressDto>();
        config.NewConfig<PhilhealthData, PhilhealthDto>();
        config.NewConfig<QuarterlyVisitData, QuarterlyVisitDto>();
    }
}
