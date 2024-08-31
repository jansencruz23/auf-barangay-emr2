using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdByHouseholdNo
{
    public class GetHouseholdByHouseholdNoRequestHandler : IRequestHandler<GetHouseholdByHouseholdNoRequest, HouseholdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHouseholdByHouseholdNoRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<HouseholdDto> Handle(GetHouseholdByHouseholdNoRequest request, CancellationToken cancellationToken)
        {
            var household = await _unitOfWork.HouseholdRepository.GetHouseholdByHouseholdNo(request.HouseholdNo);
            var householdDto = _mapper.Map<HouseholdDto>(household);

            return householdDto;
        }
    }
}
