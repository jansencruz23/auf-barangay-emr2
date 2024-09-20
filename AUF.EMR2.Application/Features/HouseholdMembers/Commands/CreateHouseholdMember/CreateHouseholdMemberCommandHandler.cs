using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household.Validators;
using AUF.EMR2.Application.DTOs.HouseholdMember.Validators;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Application.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.CreateHouseholdMember
{
    public class CreateHouseholdMemberCommandHandler : IRequestHandler<CreateHouseholdMemberCommand, BaseCommandResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateHouseholdMemberCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<Guid>> Handle(CreateHouseholdMemberCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Guid>();
            var validator = new CreateHouseholdMemberDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.HouseholdMemberDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                throw new ValidationException(validationResult);
            }

            var householdMember = _mapper.Map<HouseholdMember>(request.HouseholdMemberDto);
            householdMember = await _unitOfWork.HouseholdMemberRepository.Add(householdMember);
            await _unitOfWork.SaveAsync();

            response.Success = true;
            response.Message = "Creation is Successful";
            response.Id = householdMember.Id;

            return response;
        }
    }
}
