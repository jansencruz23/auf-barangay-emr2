using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using MapsterMapper;
using MediatR;

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
            throw new NotImplementedException();
            //var householdMember = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(request.Id);
            //var householdMemberDto = _mapper.Map<HouseholdMemberDto>(householdMember);

            //return householdMemberDto;
        }
    }
}
