using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.Households.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHousehold;

public class GetHouseholdRequestHandler : IRequestHandler<GetHouseholdQuery, ErrorOr<HouseholdQueryResponse>>
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

    public async Task<ErrorOr<HouseholdQueryResponse>> Handle(GetHouseholdQuery request, CancellationToken cancellationToken)
    {
        var household = await _unitOfWork.HouseholdRepository.GetHousehold(HouseholdId.Create(request.Id));
        var householdResponse = _mapper.Map<HouseholdQueryResponse>(household);

        return householdResponse;
    }
}
