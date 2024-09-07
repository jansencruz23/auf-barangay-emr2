using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Barangay;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Barangays.Queries.GetBarangay
{
    public class GetBarangayRequestHandler : IRequestHandler<GetBarangayRequest, BarangayDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBarangayRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BarangayDto> Handle(GetBarangayRequest request, CancellationToken cancellationToken)
        {
            var barangay = await _unitOfWork.BarangayRepository.GetBarangay();
            var barangayDto = _mapper.Map<BarangayDto>(barangay);

            return barangayDto;
        }
    }
}
