using AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;
using AUF.EMR2.Application.Features.PregnancyTrackingHhs.Commands.UpdatePregnancyTrackingHh;
using AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh;
using AUF.EMR2.Contracts.Households.Request;
using AUF.EMR2.Contracts.PregnancyTrackingHh.Request;
using AUF.EMR2.Contracts.PregnancyTrackingHh.Response;
using Mapster;

namespace AUF.EMR2.API.Common.Mappings;

public class PregnancyTrackingHhApiMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdatePregnancyTrackingHhCommand, UpdatePregnancyTrackingHhRequest>();
        config.NewConfig<GetPregnancyTrackingHhQueryResponse, PregnancyTrackingHhResponse>();
    }
}
