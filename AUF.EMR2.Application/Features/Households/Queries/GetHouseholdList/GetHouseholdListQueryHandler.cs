using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.Households.Queries.Common;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList;

public sealed class GetHouseholdListQueryHandler : IRequestHandler<GetHouseholdListQuery, ErrorOr<PagedQueryResponse<HouseholdQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetHouseholdListQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PagedQueryResponse<HouseholdQueryResponse>>> Handle(GetHouseholdListQuery request, CancellationToken cancellationToken)
    {
        var household = await _unitOfWork.HouseholdRepository.GetHouseholdList(request.RequestParams, request.Query);
        var householdResponse = _mapper.Map<List<HouseholdQueryResponse>>(household);
        var totalCount = household.TotalItemCount;

        return new PagedQueryResponse<HouseholdQueryResponse> { Data = householdResponse, TotalCount = totalCount };
    }
}
