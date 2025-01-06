using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetWraHouseholdMemberList;

public class GetWraHouseholdMemberListQueryHandler : IRequestHandler<GetWraHouseholdMemberListQuery, ErrorOr<List<HouseholdMemberQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetWraHouseholdMemberListQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<HouseholdMemberQueryResponse>>> Handle(GetWraHouseholdMemberListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var members = await _unitOfWork.HouseholdMemberRepository.GetWraHouseholdMemberList(HouseholdId.Create(request.HouseholdId));
            if (members == null)
            {
                return Errors.HouseholdMember.FailedToFetch;
            }

            return _mapper.Map<List<HouseholdMemberQueryResponse>>(members);
        }
        catch (Exception)
        {
            return Errors.HouseholdMember.FailedToFetch;
        }
    }
}
