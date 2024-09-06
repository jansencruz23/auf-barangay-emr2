using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Masterlist;
using AUF.EMR2.Application.DTOs.OralHealth;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealth
{
    public class GetOralHealthRequestHandler : IRequestHandler<GetOralHealthRequest, OralHealthDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOralHealthRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OralHealthDto> Handle(GetOralHealthRequest request, CancellationToken cancellationToken)
        {
            var record = await _unitOfWork.OralHealthRepository.GetSingleMasterlistRecord(request.Id);
            var recordDto = _mapper.Map<OralHealthDto>(record);

            return recordDto;
        }
    }
}
