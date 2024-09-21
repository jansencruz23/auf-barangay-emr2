using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.DTOs.PregnancyTracking;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackings.Queries.GetPregnancyTracking
{
    public class GetPregnancyTrackingRequestHandler : IRequestHandler<GetPregnancyTrackingRequest, PregnancyTrackingDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPregnancyTrackingRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PregnancyTrackingDto> Handle(GetPregnancyTrackingRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var pregnancyTracking = await _unitOfWork.PregnancyTrackingRepository.GetPregnancyTracking(request.Id);
            //var pregnancyTrackingDto = _mapper.Map<PregnancyTrackingDto>(pregnancyTracking);

            //return pregnancyTrackingDto;
        }
    }
}
