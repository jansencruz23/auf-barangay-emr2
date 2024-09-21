using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household.Validators;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Application.Responses;
using AutoMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.UpdateHousehold;

public class UpdateHouseholdCommandHandler : IRequestHandler<UpdateHouseholdCommand, BaseCommandResponse<Guid>>
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

    public async Task<BaseCommandResponse<Guid>> Handle(UpdateHouseholdCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //var response = new BaseCommandResponse<Guid>();
        //var validator = new UpdateHouseholdDtoValidator();
        //var validationResult = await validator.ValidateAsync(request.HouseholdDto, cancellationToken);

        //if (!validationResult.IsValid)
        //{
        //    response.Success = false;
        //    response.Message = "Updation Failed";
        //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        //    throw new ValidationException(validationResult);
        //}

        //var household = await _unitOfWork.HouseholdRepository.GetHousehold(request.HouseholdDto.Id);

        //if (household == null)
        //{
        //    response.Success = false;
        //    response.Message = $"{nameof(Household)} with id: {request.HouseholdDto.Id} is not existing";

        //    throw new NotFoundException(nameof(Household), request.HouseholdDto.Id);
        //}

        //_mapper.Map(request.HouseholdDto, household);

        //try
        //{
        //    _unitOfWork.HouseholdRepository.Update(household);
        //    await _unitOfWork.SaveAsync();
        //}
        //catch (DbUpdateConcurrencyException ex)
        //{
        //    throw new ConcurrencyException("The entity you attempted to update was modified by another user.", ex);
        //}

        //response.Success = true;
        //response.Message = "Updation is successful";
        //response.Id = request.HouseholdDto.Id;

        //return response;
    }
}
