using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistInfant;

public sealed class GetMasterlistInfantQueryHandler : IRequestHandler<GetMasterlistInfantQuery, ErrorOr<List<MasterlistChildQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMasterlistService _masterlistService;
    private readonly IMapper _mapper;

    public GetMasterlistInfantQueryHandler(
        IUnitOfWork unitOfWork,
        IMasterlistService masterlistService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _masterlistService = masterlistService;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<MasterlistChildQueryResponse>>> Handle(GetMasterlistInfantQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var members = await _masterlistService.GetMasterlistInfants(HouseholdId.Create(request.HouseholdId));
            if (members is null)
            {
                return Errors.HouseholdMember.NotFound;
            }

            var response = _mapper.Map<List<MasterlistChildQueryResponse>>(members);
            return response;
        }
        catch(Exception)
        {
            return Errors.Household.FailedToFetch;
        }           
    }
}
