using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.Barangays.Queries.Common.Responses;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Barangays.Queries.GetBarangay;

public class GetBarangayQueryHandler : IRequestHandler<GetBarangayQuery, ErrorOr<BarangayQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBarangayQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<BarangayQueryResponse>> Handle(GetBarangayQuery request, CancellationToken cancellationToken)
    {
        var barangay = await _unitOfWork.BarangayRepository.GetBarangay();

        if (barangay is null)
        {
            return Errors.Barangay.NotFound;
        }

        var response = _mapper.Map<BarangayQueryResponse>(barangay);
        return response;
    }
}
