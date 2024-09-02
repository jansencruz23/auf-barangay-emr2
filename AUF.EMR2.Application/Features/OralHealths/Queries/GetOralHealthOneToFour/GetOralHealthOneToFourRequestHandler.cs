using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Constants;
using AUF.EMR2.Application.DTOs.OralHealth;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthOneToFour
{
    public class GetOralHealthOneToFourRequestHandler : IRequestHandler<GetOralHealthOneToFourRequest, List<OralHealthDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOralHealthOneToFourRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OralHealthDto>> Handle(GetOralHealthOneToFourRequest request, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.OneToFiveStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralHealthAgeRange.OneToFiveEnd);

            var oralHealth = await _unitOfWork.OralHealthRepository.GetListQuery(request.HouseholdNo, startDate);
            var oralHealthListDto = _mapper.Map<List<OralHealthDto>>(oralHealth);

            return oralHealthListDto;
        }
    }
}
