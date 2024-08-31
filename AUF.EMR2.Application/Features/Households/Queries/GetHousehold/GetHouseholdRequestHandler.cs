using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHousehold
{
    public class GetHouseholdRequestHandler : IRequestHandler<GetHouseholdRequest, HouseholdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHouseholdRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<HouseholdDto> Handle(GetHouseholdRequest request, CancellationToken cancellationToken)
        {
            var household = await _unitOfWork.HouseholdRepository.GetHousehold(request.Id);
            var householdDto = _mapper.Map<HouseholdDto>(household);

            return householdDto;
        }
    }
}
