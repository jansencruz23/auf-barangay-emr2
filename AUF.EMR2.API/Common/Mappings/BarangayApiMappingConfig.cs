using AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay;
using AUF.EMR2.Contracts.Barangays.Requests;
using Mapster;

namespace AUF.EMR2.API.Common.Mappings;

public class BarangayApiMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateBarangayCommand, UpdateBarangayRequest>();
    }
}
