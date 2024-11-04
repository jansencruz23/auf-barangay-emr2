using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.DTOs.OralHealth;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.OralHealths.Queries.GetPrintOralHealthRecordList
{
    public class GetPrintOralHealthRecordListRequestHandler : IRequestHandler<GetPrintOralHealthRecordListRequest, PrintOralHealthDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOralHealthService _oralHealthService;
        private readonly IMapper _mapper;

        public GetPrintOralHealthRecordListRequestHandler(
            IUnitOfWork unitOfWork,
            IOralHealthService oralHealthService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _oralHealthService = oralHealthService;
            _mapper = mapper;
        }

        public async Task<PrintOralHealthDto> Handle(GetPrintOralHealthRecordListRequest request, CancellationToken cancellationToken)
        {
            var dto = new PrintOralHealthDto();

            var address = await _unitOfWork.HouseholdRepository.GetFullAddress(request.HouseholdNo);

            var infants = await _oralHealthService.GetInfants(request.HouseholdNo);
            var oneToFourChildren = await _oralHealthService.GetOneToFourChildren(request.HouseholdNo);
            var fiveToNineChildren = await _oralHealthService.GetFiveToNineChildren(request.HouseholdNo);
            var tenToFourteenChildren = await _oralHealthService.GetFiveToNineChildren(request.HouseholdNo);
            var pregnantFifteenToNineteen = await _oralHealthService.GetPregnantFifteenToNineteen(request.HouseholdNo);
            var pregnantTwentyToFourtyNine = await _oralHealthService.GetPregnantTwentyToFourtyNine(request.HouseholdNo);

            dto.Address = address;
            dto.Infants = _mapper.Map<List<OralHealthOnlyDto>>(infants);
            dto.OneToFourChildren = _mapper.Map<List<OralHealthOnlyDto>>(oneToFourChildren);
            dto.FiveToNineChildren = _mapper.Map<List<OralHealthOnlyDto>>(fiveToNineChildren);
            dto.TenToFourteenChildren = _mapper.Map<List<OralHealthOnlyDto>>(tenToFourteenChildren);
            dto.PregnantFifteenToNineteen = _mapper.Map<List<OralHealthOnlyDto>>(pregnantFifteenToNineteen);
            dto.PregnantTwentyToFourtyNine = _mapper.Map<List<OralHealthOnlyDto>>(pregnantTwentyToFourtyNine);

            return dto;
        }
    }
}
