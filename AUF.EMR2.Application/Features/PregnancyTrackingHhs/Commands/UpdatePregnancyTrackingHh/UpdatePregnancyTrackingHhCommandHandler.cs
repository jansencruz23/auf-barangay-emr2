using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.OralHealth.Validators;
using AUF.EMR2.Application.DTOs.PregnancyTrackingHh.Validators;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Application.Responses;
using AUF.EMR2.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Commands.UpdatePregnancyTrackingHh
{
    public class UpdatePregnancyTrackingHhCommandHandler : IRequestHandler<UpdatePregnancyTrackingHhCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePregnancyTrackingHhCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(UpdatePregnancyTrackingHhCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new UpdatePregnancyTrackingHhDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.PregnancyTrackingHHDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                throw new ValidationException(validationResult);
            }

            var pregnancyTrackingHh = await _unitOfWork.PregnancyTrackingHhRepository.GetPregnancyTrackingHh(request.PregnancyTrackingHHDto.Id);

            if (pregnancyTrackingHh == null)
            {
                response.Success = false;
                response.Message = $"{nameof(PregnancyTrackingHh)} with id: {request.PregnancyTrackingHHDto.Id} is not existing";

                throw new NotFoundException(nameof(PregnancyTrackingHh), request.PregnancyTrackingHHDto.Id);
            }

            _mapper.Map(request.PregnancyTrackingHHDto, pregnancyTrackingHh);

            try
            {
                _unitOfWork.PregnancyTrackingHhRepository.Update(pregnancyTrackingHh);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("The entity you attempted to update was modified by another user.", ex);
            }

            response.Success = true;
            response.Message = "Updation is successful";
            response.Id = request.PregnancyTrackingHHDto.Id;

            return response;
        }
    }
}
