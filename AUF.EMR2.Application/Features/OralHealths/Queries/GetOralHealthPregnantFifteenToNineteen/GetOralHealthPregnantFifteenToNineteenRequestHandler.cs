﻿using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;

using AUF.EMR2.Application.DTOs.OralHealth;
using MapsterMapper;
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
        private readonly IOralHealthService _oralHealthService;
        private readonly IMapper _mapper;

        public GetOralHealthPregnantFifteenToNineteenRequestHandler(
            IUnitOfWork unitOfWork,
            IOralHealthService oralHealthService, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _oralHealthService = oralHealthService;
            _mapper = mapper;
        }

        public async Task<List<OralHealthDto>> Handle(GetOralHealthPregnantFifteenToNineteenRequest request, CancellationToken cancellationToken)
        {
            var oralHealth = await _oralHealthService.GetPregnantFifteenToNineteen(request.HouseholdNo);
            var oralHealthListDto = _mapper.Map<List<OralHealthDto>>(oralHealth);

            return oralHealthListDto;
        }
    }
}
