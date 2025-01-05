using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMemberListByHouseholdNo
{
    public class GetHouseholdMemberListByHouseholdNoRequestHandler : IRequestHandler<GetHouseholdMemberListByHouseholdNoRequest, List<HouseholdMemberDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHouseholdMemberListByHouseholdNoRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<HouseholdMemberDto>> Handle(GetHouseholdMemberListByHouseholdNoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var householdMemberList = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMemberList(request.HouseholdNo);
            //var householdMemberListDto = _mapper.Map<List<HouseholdMemberDto>>(householdMemberList);

            //return householdMemberListDto;
        }
    }
}
