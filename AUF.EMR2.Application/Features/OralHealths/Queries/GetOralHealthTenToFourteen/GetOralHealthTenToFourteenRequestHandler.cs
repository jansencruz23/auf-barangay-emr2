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

namespace AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthTenToFourteen
{
    public class GetOralHealthTenToFourteenRequestHandler : IRequestHandler<GetOralHealthTenToFourteenRequest, List<OralHealthDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOralHealthTenToFourteenRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OralHealthDto>> Handle(GetOralHealthTenToFourteenRequest request, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.TenToFourteenStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralHealthAgeRange.TenToFourteenEnd);

            var oralHealth = await _unitOfWork.OralHealthRepository.GetListQuery(request.HouseholdNo, startDate);
            var oralHealthListDto = _mapper.Map<List<OralHealthDto>>(oralHealth);

            return oralHealthListDto;
        }
    }
}
