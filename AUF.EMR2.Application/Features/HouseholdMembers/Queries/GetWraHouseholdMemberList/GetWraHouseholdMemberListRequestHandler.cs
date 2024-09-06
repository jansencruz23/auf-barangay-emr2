using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetWraHouseholdMemberList
{
    public class GetWraHouseholdMemberListRequestHandler : IRequestHandler<GetWraHouseholdMemberListRequest, List<HouseholdMemberDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetWraHouseholdMemberListRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<HouseholdMemberDto>> Handle(GetWraHouseholdMemberListRequest request, CancellationToken cancellationToken)
        {
            var wraMembers = await _unitOfWork.HouseholdMemberRepository.GetWraHouseholdMemberList(request.HouseholdNo);
            var wraMemberListDto = _mapper.Map<List<HouseholdMemberDto>>(wraMembers);

            return wraMemberListDto;
        }
    }
}
