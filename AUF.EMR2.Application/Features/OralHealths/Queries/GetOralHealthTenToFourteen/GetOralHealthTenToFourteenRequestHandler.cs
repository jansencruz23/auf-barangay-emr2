using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
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
        private readonly IOralHealthService _oralHealthService;
        private readonly IMapper _mapper;

        public GetOralHealthTenToFourteenRequestHandler(
            IUnitOfWork unitOfWork,
            IOralHealthService oralHealthService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _oralHealthService = oralHealthService;
            _mapper = mapper;
        }

        public async Task<List<OralHealthDto>> Handle(GetOralHealthTenToFourteenRequest request, CancellationToken cancellationToken)
        {
            var oralHealth = await _oralHealthService.GetTenToFourteenChildren(request.HouseholdNo);
            var oralHealthListDto = _mapper.Map<List<OralHealthDto>>(oralHealth);

            return oralHealthListDto;
        }
    }
}
