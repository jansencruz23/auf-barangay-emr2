using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetAllMasterlistRecords;

public sealed class GetAllMasterlistRecordsQueryHandler : IRequestHandler<GetAllMasterlistRecordsQuery, ErrorOr<AllMasterlistRecordQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMasterlistService _masterlistService;
    private readonly ILogger<GetAllMasterlistRecordsQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetAllMasterlistRecordsQueryHandler(
        IUnitOfWork unitOfWork,
        IMasterlistService masterlistService,
        ILogger<GetAllMasterlistRecordsQueryHandler> logger,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _masterlistService = masterlistService;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AllMasterlistRecordQueryResponse>> Handle(GetAllMasterlistRecordsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var householdId = HouseholdId.Create(request.HouseholdId);
            var household = await _unitOfWork.HouseholdRepository.GetHousehold(householdId);
            var barangay = await _unitOfWork.BarangayRepository.GetBarangay();

            var newborns = await _masterlistService.GetMasterlistNewborns(householdId);
            var infants = await _masterlistService.GetMasterlistInfants(householdId);
            var underFive = await _masterlistService.GetMasterlistUnderFiveChildren(householdId);
            var schoolAged = await _masterlistService.GetMasterlistSchoolAgedChildren(householdId);
            var adolescents = await _masterlistService.GetMasterlistAdolescents(householdId);
            var adults = await _masterlistService.GetMasterlistAdults(householdId);
            var seniors = await _masterlistService.GetMasterlistSeniors(householdId);

            var form = new AllMasterlistRecordQueryResponse(
                Barangay: barangay.BarangayName,
                Midwife: "User",
                Address: household.HouseAddress.FormatAddress(),
                Newborns: _mapper.Map<List<MasterlistChildQueryResponse>>(newborns),
                Infants: _mapper.Map<List<MasterlistChildQueryResponse>>(infants),
                UnderFiveChildren: _mapper.Map<List<MasterlistChildQueryResponse>>(underFive),
                SchoolAgedChildren: _mapper.Map<List<MasterlistChildQueryResponse>>(schoolAged),
                Adolescents: _mapper.Map<List<MasterlistChildQueryResponse>>(adolescents),
                Adults: _mapper.Map<List<MasterlistAdultQueryResponse>>(adults),
                Seniors: _mapper.Map<List<MasterlistAdultQueryResponse>>(seniors)
            );

            return form;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch masterlist records for HouseholdId: {HouseholdId}", request.HouseholdId);
            return Errors.HouseholdMember.FailedToFetch;
        }
    }
}
