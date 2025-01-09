using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Constants;
using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdult;

public class GetMasterlistAdultQueryHandler : IRequestHandler<GetMasterlistAdultQuery, ErrorOr<List<MasterlistAdultQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMasterlistAdultQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<MasterlistAdultQueryResponse>>> Handle(GetMasterlistAdultQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultEnd);

            var members = await _unitOfWork.HouseholdMemberRepository.GetListQuery(HouseholdId.Create(request.HouseholdId), startDate, endDate);
            var response = _mapper.Map<List<MasterlistAdultQueryResponse>>(members);

            return response;
        }
        catch (Exception)
        {
            return Errors.Household.FailedToFetch;
        }
    }
}
