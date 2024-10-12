using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.UpdateHousehold;

public class UpdateHouseholdCommandHandler : IRequestHandler<UpdateHouseholdCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateHouseholdCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(UpdateHouseholdCommand request, CancellationToken cancellationToken)
    {
        var response = new CommandResponse<Guid>();

        var philhealth = Philhealth.Create
        (
            isHeadPhilhealthMember: request.Philhealth.IsHeadPhilhealthMember,
            philhealthNo: request.Philhealth.PhilhealthNo,
            category: request.Philhealth.Category
        );

        var houseAddress = HouseAddress.Create
        (
            houseNoAndStreet: request.HouseAddress.HouseNoAndStreet,
            barangay: request.HouseAddress.Barangay,
            city: request.HouseAddress.City,
            province: request.HouseAddress.Province
        );

        var household = await _unitOfWork.HouseholdRepository.GetHousehold(HouseholdId.Create(request.Id));

        if (household is null)
        {
            return Errors.Household.IdNotFound;
        }

        household.UpdateHousehold(
            householdNo: request.HouseholdNo,
            firstQtrVisit: request.FirstQtrVisit,
            secondQtrVisit: request.SecondQtrVisit,
            thirdQtrVisit: request.ThirdQtrVisit,
            fourthQtrVisit: request.FourthQtrVisit,
            lastName: request.LastName,
            firstName: request.FirstName,
            motherMaidenName: request.MotherMaidenName,
            contactNo: request.ContactNo,
            isNhts: request.IsNhts,
            isIp: request.IsIp,
            philhealth: philhealth,
            houseAddress: houseAddress
        );

        _unitOfWork.HouseholdRepository.Update(household);
        await _unitOfWork.SaveAsync();

        response.Success = true;
        response.Id = household.Id.Value;
        response.Message = "Updated successfully";

        return response;
    }
}
