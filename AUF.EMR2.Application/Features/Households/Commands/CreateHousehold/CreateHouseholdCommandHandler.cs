using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.DTOs.Household.Validators;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Application.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold
{
    public class CreateHouseholdCommandHandler : IRequestHandler<CreateHouseholdCommand, BaseCommandResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPregnancyTrackingHHService _pregnancyTrackingHHService;
        private readonly IMapper _mapper;

        public CreateHouseholdCommandHandler(
            IUnitOfWork unitOfWork,
            IPregnancyTrackingHHService pregnancyTrackingHHService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _pregnancyTrackingHHService = pregnancyTrackingHHService;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Guid>> Handle(CreateHouseholdCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Guid>();
            var validator = new CreateHouseholdDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.HouseholdDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                throw new ValidationException(validationResult);
            }

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var household = _mapper.Map<Household>(request.HouseholdDto);
                    household = await _unitOfWork.HouseholdRepository.Add(household);
                    await _unitOfWork.SaveAsync();

                    var pregnancyTrackingHh = await _pregnancyTrackingHHService.CreatePregnancyTrackingHH(household.Id);
                    pregnancyTrackingHh = await _unitOfWork.PregnancyTrackingHhRepository.Add(pregnancyTrackingHh);

                    await _unitOfWork.SaveAsync();
                    await _unitOfWork.CommitTransactionAsync();

                    response.Success = true;
                    response.Message = "Creation is Successful";
                    response.Id = household.Id;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";

                    await _unitOfWork.RollbackTransactionAsync();
                    throw new DataIntegrityException("Error while creating household and pregnancy tracking hh", ex);
                }
            }

            return response;
        }
    }
}
