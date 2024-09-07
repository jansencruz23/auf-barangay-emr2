using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.DTOs.PregnancyTracking;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Queries.GetPregnancyTrackingList
{
    public class GetPregnancyTrackingListRequestHandler : IRequestHandler<GetPregnancyTrackingListRequest, List<PregnancyTrackingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPregnancyTrackingListRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PregnancyTrackingDto>> Handle(GetPregnancyTrackingListRequest request, CancellationToken cancellationToken)
        {
            var pregnancyTrackingList = await _unitOfWork.PregnancyTrackingRepository.GetPregnancyTrackingList(request.HouseholdNo);
            var pregnancyTrackingListDto = _mapper.Map<List<PregnancyTrackingDto>>(pregnancyTrackingList);

            return pregnancyTrackingListDto;
        }
    }
}
