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

namespace AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthInfant
{
    public class GetOralHealthInfantRequestHandler : IRequestHandler<GetOralHealthInfantRequest, List<OralHealthDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOralHealthInfantRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OralHealthDto>> Handle(GetOralHealthInfantRequest request, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.InfantStart).AddDays(1);

            var oralHealth = await _unitOfWork.OralHealthRepository.GetListQuery(request.HouseholdNo, startDate);
            var oralHealthListDto = _mapper.Map<List<OralHealthDto>>(oralHealth);

            return oralHealthListDto;
        }
    }
}
