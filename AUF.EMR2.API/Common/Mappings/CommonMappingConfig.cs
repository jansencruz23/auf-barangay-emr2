using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Contracts.Common.Responses;
using Mapster;

namespace AUF.EMR2.API.Common.Mappings;

public class CommonMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig(typeof(CommandResponse<>), typeof(ApiResponse<>));
        config.NewConfig(typeof(PagedQueryResponse<>), typeof(ApiPagedResponse<>));
    }
}
