using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Masterlist.Validators;
using AUF.EMR2.Application.DTOs.OralHealth.Validators;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.OralHealths.Commands.UpdateOralHealth
{
    public class UpdateOralHealthCommandHandler : IRequestHandler<UpdateOralHealthCommand, BaseCommandResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOralHealthCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Guid>> Handle(UpdateOralHealthCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var response = new BaseCommandResponse<Guid>();
            //var validator = new UpdateOralHealthDtoValidator();
            //var validationResult = await validator.ValidateAsync(request.OralHealthDto, cancellationToken);

            //if (!validationResult.IsValid)
            //{
            //    response.Success = false;
            //    response.Message = "Updation Failed";
            //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            //    throw new ValidationException(validationResult);
            //}

            //var householdMember = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(request.OralHealthDto.Id);

            //if (householdMember == null)
            //{
            //    response.Success = false;
            //    response.Message = $"{nameof(HouseholdMember)} with id: {request.OralHealthDto.Id} is not existing";

            //    throw new NotFoundException(nameof(HouseholdMember), request.OralHealthDto.Id);
            //}

            //_mapper.Map(request.OralHealthDto, householdMember);

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
            //response.Id = request.OralHealthDto.Id;

            //return response;
        }
    }
}
