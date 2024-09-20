using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household.Validators;
using AUF.EMR2.Application.DTOs.WomanOfReproductiveAge.Validators;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Application.Responses;
using AUF.EMR2.Domain.Aggregates;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Commands.CreateWra
{
    public class CreateWraCommandHandler : IRequestHandler<CreateWraCommand, BaseCommandResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateWraCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Guid>> Handle(CreateWraCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Guid>();
            var validator = new CreateWraDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.WraDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                throw new ValidationException(validationResult);
            }

            var wra = _mapper.Map<WomanOfReproductiveAge>(request.WraDto);
            wra = await _unitOfWork.WraRepository.Add(wra);
            await _unitOfWork.SaveAsync();

            response.Success = true;
            response.Message = "Creation is Successful";
            response.Id = wra.Id;

            return response;
        }
    }
}
