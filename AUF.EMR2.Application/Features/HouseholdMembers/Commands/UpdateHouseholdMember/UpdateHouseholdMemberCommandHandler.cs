using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.UpdateHouseholdMember;

public class UpdateHouseholdMemberCommandHandler : IRequestHandler<UpdateHouseholdMemberCommand, BaseCommandResponse<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateHouseholdMemberCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<Guid>> Handle(UpdateHouseholdMemberCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //var response = new BaseCommandResponse<Guid>();
        //var validator = new UpdateHouseholdMemberDtoValidator(_unitOfWork);
        //var validationResult = await validator.ValidateAsync(request.HouseholdMemberDto, cancellationToken);

        //if (!validationResult.IsValid)
        //{
        //    response.Success = false;
        //    response.Message = "Updation Failed";
        //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        //    throw new ValidationException(validationResult);
        //}

        //var householdMember = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(request.HouseholdMemberDto.Id);

        //if (householdMember == null)
        //{
        //    response.Success = false;
        //    response.Message = $"{nameof(HouseholdMember)} with id: {request.HouseholdMemberDto.Id} is not existing";

        //    throw new NotFoundException(nameof(HouseholdMember), request.HouseholdMemberDto.Id);
        //}

        //_mapper.Map(request.HouseholdMemberDto, householdMember);

        //try
        //{
        //    _unitOfWork.HouseholdMemberRepository.Update(householdMember);
        //    await _unitOfWork.SaveAsync();
        //}
        //catch (DbUpdateConcurrencyException ex)
        //{
        //    throw new ConcurrencyException("The entity you attempted to update was modified by another user.", ex);
        //}

        //response.Success = true;
        //response.Message = "Updation is successful";
        //response.Id = request.HouseholdMemberDto.Id;

        //return response;
    }
}
