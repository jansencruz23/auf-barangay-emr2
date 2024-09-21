using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.DTOs.PregnancyTrackingHh;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh
{
    public class GetPregnancyTrackingHhRequestHandler : IRequestHandler<GetPregnancyTrackingHhRequest, PregnancyTrackingHhDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPregnancyTrackingHhRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PregnancyTrackingHhDto> Handle(GetPregnancyTrackingHhRequest request, CancellationToken cancellationToken)
        {
            var pregnancyTrackingHh = await _unitOfWork.PregnancyTrackingHhRepository.GetPregnancyTrackingHh(request.HouseholdNo);
            var pregnancyTrackingHhDto = _mapper.Map<PregnancyTrackingHhDto>(pregnancyTrackingHh);

            return pregnancyTrackingHhDto;
        }
    }
}
