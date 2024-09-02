using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.DTOs.Masterlist;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdultDetail
{
    public class GetMasterlistAdultDetailRequestHandler : IRequestHandler<GetMasterlistAdultDetailRequest, MasterlistAdultDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMasterlistAdultDetailRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MasterlistAdultDto> Handle(GetMasterlistAdultDetailRequest request, CancellationToken cancellationToken)
        {
            var adult = await _unitOfWork.MasterlistRepository.GetSingleMasterlistRecord(request.Id);
            var adultDto = _mapper.Map<MasterlistAdultDto>(adult);

            return adultDto;
        }
    }
}
