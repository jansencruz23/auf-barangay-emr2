using AUF.EMR2.Application.Features.Barangays.Queries.Common.Responses;
using AUF.EMR2.Domain.Aggregates.BarangayAggregate;
using Mapster;

namespace AUF.EMR2.Application.Common.Mapping;

public sealed class BarangayMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Barangay, BarangayQueryResponse>()
           .Map(dest => dest.Id, src => src.Id.Value);
    }
}
