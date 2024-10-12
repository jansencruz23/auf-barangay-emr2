using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;

public class CreateHouseholdCommandHandler(
    IUnitOfWork unitOfWork,
    IPregnancyTrackingHHService pregnancyTrackingHhService,
    IMapper mapper) : IRequestHandler<CreateHouseholdCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IPregnancyTrackingHHService _pregnancyTrackingHhService = pregnancyTrackingHhService;
    private readonly IMapper _mapper = mapper;

    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(CreateHouseholdCommand request, CancellationToken cancellationToken)
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

        var household = Household.Create
        (
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

        await _unitOfWork.HouseholdRepository.Add(household);
        await _unitOfWork.SaveAsync();

        response.Success = true;
        response.Id = household.Id.Value;
        response.Message = "Created successfully";

        return response;


        //var response = new BaseCommandResponse<Guid>();
        //var validator = new CreateHouseholdDtoValidator(_unitOfWork);
        //var validationResult = await validator.ValidateAsync(request.HouseholdDto, cancellationToken);

        //if (!validationResult.IsValid)
        //{
        //    response.Success = false;
        //    response.Message = "Creation Failed";
        //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        //    throw new ValidationException(validationResult);
        //}

        //using (var transaction = await _unitOfWork.BeginTransactionAsync())
        //{
        //    try
        //    {
        //        var household = _mapper.Map<Household>(request.HouseholdDto);
        //        household = await _unitOfWork.HouseholdRepository.Add(household);
        //        await _unitOfWork.SaveAsync();

        //        var pregnancyTrackingHh = await _pregnancyTrackingHHService.CreatePregnancyTrackingHH(household.Id);
        //        pregnancyTrackingHh = await _unitOfWork.PregnancyTrackingHhRepository.Add(pregnancyTrackingHh);

        //        await _unitOfWork.SaveAsync();
        //        await _unitOfWork.CommitTransactionAsync();

        //        response.Success = true;
        //        response.Message = "Creation is Successful";
        //        response.Id = household.Id;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Creation Failed";

        //        await _unitOfWork.RollbackTransactionAsync();
        //        throw new DataIntegrityException("Error while creating household and pregnancy tracking hh", ex);
        //    }
        //}

        //return response;
    }
}
