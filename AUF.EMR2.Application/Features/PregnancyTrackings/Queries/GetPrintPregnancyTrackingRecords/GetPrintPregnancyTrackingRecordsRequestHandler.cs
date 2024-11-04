using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.PregnancyTracking;
using AUF.EMR2.Application.DTOs.PregnancyTrackingHh;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Queries.GetPrintPregnancyTrackingRecords
{
    public class GetPrintPregnancyTrackingRecordsRequestHandler : IRequestHandler<GetPrintPregnancyTrackingRecordsRequest, PrintPregnancyTrackingDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPrintPregnancyTrackingRecordsRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PrintPregnancyTrackingDto> Handle(GetPrintPregnancyTrackingRecordsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var dto = new PrintPregnancyTrackingDto();

            //var pregnancyTrackingHh = await _unitOfWork.PregnancyTrackingHhRepository.GetPregnancyTrackingHh(request.HouseholdNo);
            //var pregnancyTrackingList = await _unitOfWork.PregnancyTrackingRepository.GetPregnancyTrackingList(request.HouseholdNo);

            //dto.PregnancyTrackingHh = _mapper.Map<PregnancyTrackingHhOnlyDto>(pregnancyTrackingHh);
            //dto.PregnancyTrackingList = _mapper.Map<List<PregnancyTrackingDto>>(pregnancyTrackingList);

            //return dto;
        }
    }
}
