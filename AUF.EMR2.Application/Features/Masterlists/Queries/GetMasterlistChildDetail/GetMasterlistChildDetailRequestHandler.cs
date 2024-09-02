using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Masterlist;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistChildDetail
{
    public class GetMasterlistChildDetailRequestHandler : IRequestHandler<GetMasterlistChildDetailRequest, MasterlistChildDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMasterlistChildDetailRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MasterlistChildDto> Handle(GetMasterlistChildDetailRequest request, CancellationToken cancellationToken)
        {
            var child = await _unitOfWork.MasterlistRepository.GetSingleMasterlistRecord(request.Id);
            var childDto = _mapper.Map<MasterlistChildDto>(child);

            return childDto;
        }
    }
}
