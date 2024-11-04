using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.DTOs.Masterlist;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetPrintMasterlistRecordList
{
    public class GetPrintMasterlistRecordListRequestHandler : IRequestHandler<GetPrintMasterlistRecordListRequest, PrintMasterlistRecordsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMasterlistService _masterlistService;
        private readonly IMapper _mapper;

        public GetPrintMasterlistRecordListRequestHandler(
            IUnitOfWork unitOfWork,
            IMasterlistService masterlistService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _masterlistService = masterlistService;
            _mapper = mapper;
        }

        public async Task<PrintMasterlistRecordsDto> Handle(GetPrintMasterlistRecordListRequest request, CancellationToken cancellationToken)
        {
            var dto = new PrintMasterlistRecordsDto();

            var address = await _unitOfWork.HouseholdRepository.GetFullAddress(request.HouseholdNo);

            var newborns = await _masterlistService.GetMasterlistNewborns(request.HouseholdNo);
            var infants = await _masterlistService.GetMasterlistInfants(request.HouseholdNo);
            var underFive = await _masterlistService.GetMasterlistUnderFiveChildren(request.HouseholdNo);
            var schoolAged = await _masterlistService.GetMasterlistSchoolAgedChildren(request.HouseholdNo);
            var adolescents = await _masterlistService.GetMasterlistAdolescents(request.HouseholdNo);
            var adults = await _masterlistService.GetMasterlistAdults(request.HouseholdNo);
            var seniors = await _masterlistService.GetMasterlistSeniors(request.HouseholdNo);

            dto.Address = address;
            dto.Newborns = _mapper.Map<List<MasterlistChildOnlyDto>>(newborns);
            dto.Infants = _mapper.Map<List<MasterlistChildOnlyDto>>(infants);
            dto.UnderFiveChildren = _mapper.Map<List<MasterlistChildOnlyDto>>(underFive);
            dto.SchoolAgedChildren = _mapper.Map<List<MasterlistChildOnlyDto>>(schoolAged);
            dto.Adolescents = _mapper.Map<List<MasterlistChildOnlyDto>>(adolescents);
            dto.Adults = _mapper.Map<List<MasterlistAdultOnlyDto>>(adults);
            dto.Seniors = _mapper.Map<List<MasterlistAdultOnlyDto>>(seniors);

            return dto;
        }
    }
}
