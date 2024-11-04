using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Commands.CreatePregnancyTracking;

public class CreatePregnancyTrackingCommandHandler : IRequestHandler<CreatePregnancyTrackingCommand, CommandResponse<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePregnancyTrackingCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommandResponse<Guid>> Handle(CreatePregnancyTrackingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //var response = new BaseCommandResponse<Guid>();
        //var validator = new CreatePregnancyTrackingDtoValidator(_unitOfWork);
        //var validationResult = await validator.ValidateAsync(request.PregnancyTrackingDto, cancellationToken);

        //if (!validationResult.IsValid)
        //{
        //    response.Success = false;
        //    response.Message = "Creation Failed";
        //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        //    throw new ValidationException(validationResult);
        //}

        //var pregnancyTracking = _mapper.Map<PregnancyTracking>(request.PregnancyTrackingDto);
        //pregnancyTracking = await _unitOfWork.PregnancyTrackingRepository.Add(pregnancyTracking);
        //await _unitOfWork.SaveAsync();

        //response.Success = true;
        //response.Message = "Creation is Successful";
        //response.Id = pregnancyTracking.Id;

        //return response;
    }
}
