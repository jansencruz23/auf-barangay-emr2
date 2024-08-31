using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMember
{
    public class GetHouseholdMemberRequestHandler : IRequestHandler<GetHouseholdMemberRequest, HouseholdMemberDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHouseholdMemberRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<HouseholdMemberDto> Handle(GetHouseholdMemberRequest request, CancellationToken cancellationToken)
        {
            var householdMember = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(request.Id);
            var householdMemberDto = _mapper.Map<HouseholdMemberDto>(householdMember);

            return householdMemberDto;
        }
    }
}
