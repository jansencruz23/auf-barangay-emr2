using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Household.Validators;
using AUF.EMR2.Application.DTOs.PregnancyTracking.Validators;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Commands.CreatePregnancyTracking
{
    public class CreatePregnancyTrackingCommandHandler : IRequestHandler<CreatePregnancyTrackingCommand, BaseCommandResponse<Guid>>
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

        public async Task<BaseCommandResponse<Guid>> Handle(CreatePregnancyTrackingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Guid>();
            var validator = new CreatePregnancyTrackingDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.PregnancyTrackingDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                throw new ValidationException(validationResult);
            }

            var pregnancyTracking = _mapper.Map<PregnancyTracking>(request.PregnancyTrackingDto);
            pregnancyTracking = await _unitOfWork.PregnancyTrackingRepository.Add(pregnancyTracking);
            await _unitOfWork.SaveAsync();

            response.Success = true;
            response.Message = "Creation is Successful";
            response.Id = pregnancyTracking.Id;

            return response;
        }
    }
}
