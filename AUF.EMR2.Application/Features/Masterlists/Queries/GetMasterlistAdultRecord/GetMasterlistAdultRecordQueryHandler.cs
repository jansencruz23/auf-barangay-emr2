using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdultRecord;

public sealed class GetMasterlistAdultRecordQueryHandler : IRequestHandler<GetMasterlistAdultRecordQuery, ErrorOr<MasterlistAdultQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMasterlistAdultRecordQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<MasterlistAdultQueryResponse>> Handle(GetMasterlistAdultRecordQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var member = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(HouseholdMemberId.Create(request.Id));
            if (member is null)
            {
                return Errors.HouseholdMember.NotFound;
            }

            return _mapper.Map<MasterlistAdultQueryResponse>(member);
        }
        catch (Exception)
        {
            return Errors.HouseholdMember.FailedToFetch;
        }
    }
}
