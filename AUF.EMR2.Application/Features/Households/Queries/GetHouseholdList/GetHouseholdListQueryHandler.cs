using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using AUF.EMR2.Application.Features.Households.Queries.Common;
using AUF.EMR2.Domain.Common.Errors;
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
        try
        {
            var households = await _unitOfWork.HouseholdRepository.GetHouseholdList(request.RequestParams, request.Query);
            if (households == null)
            {
                return Errors.Household.FailedToFetch;
            }

            var householdIds = households.Select(h => h.Id).ToList();

            // Create a dictionary for faster lookup of members by household ID
            var membersByHousehold = (await _unitOfWork.HouseholdMemberRepository
                .GetHouseholdMemberList(householdIds))
                .GroupBy(m => m.HouseholdId)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Map households to response and attach members
            var householdResponse = households.Select(h =>
            {
                var response = _mapper.Map<HouseholdQueryResponse>(h);

                // Get members for this household from the lookup dictionary
                if (membersByHousehold.TryGetValue(h.Id, out var members))
                {
                    response.SetHouseholdMembers(_mapper.Map<List<HouseholdMemberQueryResponse>>(members));
                }
                return response;
            }).ToList();

            var totalCount = households.TotalItemCount;
            return new PagedQueryResponse<HouseholdQueryResponse> { Data = householdResponse, TotalCount = totalCount };
        }
        catch (Exception)
        {
            return Errors.Household.FailedToFetch;
        }
    }
}
