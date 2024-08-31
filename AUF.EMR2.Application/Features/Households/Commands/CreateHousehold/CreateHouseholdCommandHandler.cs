using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household.Validators;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Application.Responses;
using AUF.EMR2.Domain.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold
{
    public class CreateHouseholdCommandHandler : IRequestHandler<CreateHouseholdCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateHouseholdCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateHouseholdCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateHouseholdDtoValidator();
            var validationResult = await validator.ValidateAsync(request.HouseholdDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                throw new ValidationException(validationResult);
            }

            var household = _mapper.Map<Household>(request.HouseholdDto);
            household = await _unitOfWork.HouseholdRepository.Add(household);
            await _unitOfWork.SaveAsync();

            response.Success = true;
            response.Message = "Creation is Successful";
            response.Id = household.Id;

            return response;
        }
    }
}
