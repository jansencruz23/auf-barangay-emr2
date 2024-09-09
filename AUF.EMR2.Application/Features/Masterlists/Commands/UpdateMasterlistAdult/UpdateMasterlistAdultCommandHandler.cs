using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.HouseholdMember.Validators;
using AUF.EMR2.Application.DTOs.Masterlist.Validators;
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

namespace AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistAdult
{
    public class UpdateMasterlistAdultCommandHandler : IRequestHandler<UpdateMasterlistAdultCommand, BaseCommandResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMasterlistAdultCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Guid>> Handle(UpdateMasterlistAdultCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Guid>();
            var validator = new UpdateMasterlistAdultDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MasterlistDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                throw new ValidationException(validationResult);
            }

            var householdMember = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(request.MasterlistDto.Id);

            if (householdMember == null)
            {
                response.Success = false;
                response.Message = $"{nameof(HouseholdMember)} with id: {request.MasterlistDto.Id} is not existing";

                throw new NotFoundException(nameof(HouseholdMember), request.MasterlistDto.Id);
            }

            _mapper.Map(request.MasterlistDto, householdMember);

            try
            {
                _unitOfWork.HouseholdMemberRepository.Update(householdMember);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("The entity you attempted to update was modified by another user.", ex);
            }

            response.Success = true;
            response.Message = "Updation is successful";
            response.Id = request.MasterlistDto.Id;

            return response;
        }
    }
}
