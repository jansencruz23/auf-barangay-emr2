using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using AUF.EMR2.Application.Features.Households.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHousehold;

public class GetHouseholdQueryHandler : IRequestHandler<GetHouseholdQuery, ErrorOr<HouseholdQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetHouseholdQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<HouseholdQueryResponse>> Handle(GetHouseholdQuery request, CancellationToken cancellationToken)
    {
        var household = await _unitOfWork.HouseholdRepository.GetHousehold(HouseholdId.Create(request.Id));

        if (household is null)
        {
            return Errors.Household.NotFound;
        }

        var members = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMemberList(request.Id);
        var response = _mapper.Map<HouseholdQueryResponse>(household);
        response.SetHouseholdMembers(_mapper.Map<List<HouseholdMemberQueryResponse>>(members));

        return response;
    }
}
