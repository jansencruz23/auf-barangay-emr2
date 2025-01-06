using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMember;

public sealed class GetHouseholdMemberQueryHandler : IRequestHandler<GetHouseholdMemberQuery, ErrorOr<HouseholdMemberQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetHouseholdMemberQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<HouseholdMemberQueryResponse>> Handle(GetHouseholdMemberQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var member = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(HouseholdMemberId.Create(request.Id));
            if (member is null)
            {   
                return Errors.HouseholdMember.NotFound;
            }

            return _mapper.Map<HouseholdMemberQueryResponse>(member);
        }
        catch (Exception)
        {
            return Errors.HouseholdMember.FailedToFetch;
        }
    }
}
