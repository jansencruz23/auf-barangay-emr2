using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Barangay.Validators;
using AUF.EMR2.Application.DTOs.Household.Validators;
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

namespace AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay
{
    public class UpdateBarangayCommandHandler : IRequestHandler<UpdateBarangayCommand, BaseCommandResponse<Guid>>
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

        public async Task<BaseCommandResponse<Guid>> Handle(UpdateBarangayCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Guid>();
            var validator = new UpdateBarangayDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BarangayDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                throw new ValidationException(validationResult);
            }

            var barangay = await _unitOfWork.BarangayRepository.GetBarangay();

            if (barangay == null)
            {
                response.Success = false;
                response.Message = $"{nameof(Barangay)} with id: {request.BarangayDto.Id} is not existing";

                throw new NotFoundException(nameof(Barangay), request.BarangayDto.Id);
            }

            _mapper.Map(request.BarangayDto, barangay);

            try
            {
                _unitOfWork.BarangayRepository.Update(barangay);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("The entity you attempted to update was modified by another user.", ex);
            }

            response.Success = true;
            response.Message = "Updation is successful";
            response.Id = request.BarangayDto.Id;

            return response;
        }
    }
}
