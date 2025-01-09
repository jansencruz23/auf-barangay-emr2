using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using AUF.EMR2.Contracts.Masterlist.Responses;
using Mapster;

namespace AUF.EMR2.API.Common.Mappings;

public sealed class MasterlistApiMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MasterlistChildResponse, MasterlistChildQueryResponse>();
        config.NewConfig<MasterlistAdultResponse, MasterlistAdultQueryResponse>();
    }
}
