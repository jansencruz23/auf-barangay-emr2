using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh;

public class GetPregnancyTrackingHhQueryHandler : IRequestHandler<GetPregnancyTrackingHhQuery, ErrorOr<GetPregnancyTrackingHhQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPregnancyTrackingHhQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<GetPregnancyTrackingHhQueryResponse>> Handle(GetPregnancyTrackingHhQuery request, CancellationToken cancellationToken)
    {
        var pregTrackHh = await _unitOfWork.PregnancyTrackingHhRepository
            .GetPregnancyTrackingHh(HouseholdId.Create(request.HouseholdId));

        if (pregTrackHh is null)
        {
            return Errors.PregnancyTrackingHh.NotFound;
        }

        var response = _mapper.Map<GetPregnancyTrackingHhQueryResponse>(pregTrackHh);
        return response;
    }
}
