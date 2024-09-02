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

namespace AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthPregnantFifteenToNineteen
{
    public class GetOralHealthPregnantFifteenToNineteenRequestHandler : IRequestHandler<GetOralHealthPregnantFifteenToNineteenRequest, List<OralHealthDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOralHealthPregnantFifteenToNineteenRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OralHealthDto>> Handle(GetOralHealthPregnantFifteenToNineteenRequest request, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.FifteenToNineteenStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralHealthAgeRange.FifteenToNineteenEnd);

            var oralHealth = await _unitOfWork.OralHealthRepository.GetPregnantHouseholdMembers(request.HouseholdNo, startDate, endDate);
            var oralHealthListDto = _mapper.Map<List<OralHealthDto>>(oralHealth);

            return oralHealthListDto;
        }
    }
}
