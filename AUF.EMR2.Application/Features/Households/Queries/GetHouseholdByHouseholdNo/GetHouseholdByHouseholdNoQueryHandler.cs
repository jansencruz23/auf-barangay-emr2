using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.Households.Queries.Common;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdByHouseholdNo;

public class GetHouseholdByHouseholdNoQueryHandler : IRequestHandler<GetHouseholdByHouseholdNoQuery, ErrorOr<HouseholdQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetHouseholdByHouseholdNoQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ErrorOr<HouseholdQueryResponse>> Handle(GetHouseholdByHouseholdNoQuery request, CancellationToken cancellationToken)
    {
        var household = await _unitOfWork.HouseholdRepository.GetHouseholdByHouseholdNo(request.HouseholdNo);
        var householdDto = _mapper.Map<HouseholdQueryResponse>(household);

        return householdDto;
    }
}
