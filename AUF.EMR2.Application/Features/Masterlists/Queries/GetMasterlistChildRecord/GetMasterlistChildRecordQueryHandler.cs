using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistChildRecord;

public sealed class GetMasterlistChildRecordQueryHandler : IRequestHandler<GetMasterlistChildRecordQuery, ErrorOr<MasterlistChildQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMasterlistChildRecordQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<MasterlistChildQueryResponse>> Handle(GetMasterlistChildRecordQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var member = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(HouseholdMemberId.Create(request.Id));
            if (member is null)
            {
                return Errors.HouseholdMember.NotFound;
            }

            return _mapper.Map<MasterlistChildQueryResponse>(member);
        }
        catch (Exception)
        {
            return Errors.HouseholdMember.FailedToFetch;
        }
    }
}
