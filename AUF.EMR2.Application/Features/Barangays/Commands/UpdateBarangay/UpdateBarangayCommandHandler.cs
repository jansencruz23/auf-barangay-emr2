using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using System.Data;

namespace AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay;

public class UpdateBarangayCommandHandler : IRequestHandler<UpdateBarangayCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBarangayCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(UpdateBarangayCommand request, CancellationToken cancellationToken)
    {
        var barangay = await _unitOfWork.BarangayRepository.GetBarangay();

        if (barangay is null)
        {
            return Errors.Barangay.NotFound;
        }

        var response = new CommandResponse<Guid>();

        var barangayAddress = BarangayAddress.Create(
            street: request.Street,
            municipality: request.Municipality,
            province: request.Province,
            region: request.Region
        );

        barangay.Update(
            barangayName: request.BarangayName,
            logo: request.Logo,
            barangayAddress: barangayAddress,
            contactNo: request.ContactNo,
            barangayHealthStation: request.BarangayHealthStation,
            ruralHealthUnit: request.RuralHealthUnit,
            description: request.Description
        );

        try
        {
            _unitOfWork.BarangayRepository.Update(barangay);
            await _unitOfWork.SaveAsync();
        }
        catch (DBConcurrencyException)
        {
            return Errors.ConcurrentIssue;
        }

        response.Success = true;
        response.Id = barangay.Id.Value;
        response.Message = "Updated successfully";

        return response;
    }
}
