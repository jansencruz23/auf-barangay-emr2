using AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay;
using AUF.EMR2.Application.Features.Barangays.Common;
using AUF.EMR2.Application.Features.Barangays.Queries.Common.Responses;
using AUF.EMR2.Contracts.Barangays.Common.ValueObjectDtos;
using AUF.EMR2.Contracts.Barangays.Requests;
using AUF.EMR2.Contracts.Barangays.Responses;
using Mapster;

namespace AUF.EMR2.API.Common.Mappings;

public sealed class BarangayApiMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateBarangayCommand, UpdateBarangayRequest>();
        config.NewConfig<BarangayResponse, BarangayQueryResponse>();

        config.NewConfig<BarangayAddressData, BarangayAddressDto>();
    }
}
