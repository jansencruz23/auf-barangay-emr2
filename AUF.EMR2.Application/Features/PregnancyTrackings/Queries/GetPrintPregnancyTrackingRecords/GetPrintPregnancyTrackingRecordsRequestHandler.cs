﻿using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.PregnancyTracking;
using AutoMapper;
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

        public Task<PrintPregnancyTrackingDto> Handle(GetPrintPregnancyTrackingRecordsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
