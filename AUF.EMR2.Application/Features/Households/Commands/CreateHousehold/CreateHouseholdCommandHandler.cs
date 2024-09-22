using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;

public class CreateHouseholdCommandHandler : IRequestHandler<CreateHouseholdCommand, ErrorOr<BaseCommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPregnancyTrackingHHService _pregnancyTrackingHHService;
    private readonly IMapper _mapper;

    public CreateHouseholdCommandHandler(
        IUnitOfWork unitOfWork,
        IPregnancyTrackingHHService pregnancyTrackingHHService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _pregnancyTrackingHHService = pregnancyTrackingHHService;
        _mapper = mapper;
    }

    public async Task<ErrorOr<BaseCommandResponse<Guid>>> Handle(CreateHouseholdCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<Guid>();

        if (!await _unitOfWork.HouseholdRepository.IsHouseholdNoAvailable(request.HouseholdDto.HouseholdNo))
        {
            return Errors.Household.DuplicateHouseholdNo;
        }

        var dto = request.HouseholdDto;

        var philhealth = Philhealth.Create
        (
            isHeadPhilhealthMember: dto.Philhealth.IsHeadPhilhealthMember,
            philhealthNo: dto.Philhealth.PhilhealthNo,
            category: dto.Philhealth.Category
        );

        var houseAddress = HouseAddress.Create
        (
            houseNoAndStreet: dto.HouseAddress.HouseNoAndStreet,
            barangay: dto.HouseAddress.Barangay,
            city: dto.HouseAddress.City,
            province: dto.HouseAddress.Province
        );

        var household = Household.Create
        (
            householdNo: dto.HouseholdNo,
            firstQtrVisit: dto.FirstQtrVisit,
            secondQtrVisit: dto.SecondQtrVisit,
            thirdQtrVisit: dto.ThirdQtrVisit,
            fourthQtrVisit: dto.FourthQtrVisit,
            lastName: dto.LastName,
            firstName: dto.FirstName,
            motherMaidenName: dto.MotherMaidenName,
            contactNo: dto.ContactNo,
            isNhts: dto.IsNhts,
            isIp: dto.IsIp,
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
