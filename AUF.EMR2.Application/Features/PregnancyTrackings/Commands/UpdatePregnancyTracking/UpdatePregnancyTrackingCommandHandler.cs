using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.HouseholdMember.Validators;
using AUF.EMR2.Application.DTOs.PregnancyTracking.Validators;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Commands.UpdatePregnancyTracking
{
    public class UpdatePregnancyTrackingCommandHandler : IRequestHandler<UpdatePregnancyTrackingCommand, CommandResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePregnancyTrackingCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<Guid>> Handle(UpdatePregnancyTrackingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var response = new BaseCommandResponse<Guid>();
            //var validator = new UpdatePregnancyTrackingDtoValidator(_unitOfWork);
            //var validationResult = await validator.ValidateAsync(request.PregnancyTrackingDto, cancellationToken);

            //if (!validationResult.IsValid)
            //{
            //    response.Success = false;
            //    response.Message = "Updation Failed";
            //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            //    throw new ValidationException(validationResult);
            //}

            //var pregnancyTracking = await _unitOfWork.PregnancyTrackingRepository.GetPregnancyTracking(request.PregnancyTrackingDto.Id);

            //if (pregnancyTracking == null)
            //{
            //    response.Success = false;
            //    response.Message = $"{nameof(PregnancyTracking)} with id: {request.PregnancyTrackingDto.Id} is not existing";

            //    throw new NotFoundException(nameof(PregnancyTracking), request.PregnancyTrackingDto.Id);
            //}

            //_mapper.Map(request.PregnancyTrackingDto, pregnancyTracking);

            //try
            //{
            //    _unitOfWork.PregnancyTrackingRepository.Update(pregnancyTracking);
            //    await _unitOfWork.SaveAsync();
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    throw new ConcurrencyException("The entity you attempted to update was modified by another user.", ex);
            //}

            //response.Success = true;
            //response.Message = "Updation is successful";
            //response.Id = request.PregnancyTrackingDto.Id;

            //return response;
        }
    }
}
