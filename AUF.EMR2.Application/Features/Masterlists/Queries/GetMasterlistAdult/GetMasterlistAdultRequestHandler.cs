using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Constants;
using AUF.EMR2.Application.DTOs.Masterlist;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdult
{
    public class GetMasterlistAdultRequestHandler : IRequestHandler<GetMasterlistAdultRequest, List<MasterlistAdultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMasterlistService _masterlistService;
        private readonly IMapper _mapper;

        public GetMasterlistAdultRequestHandler(
            IUnitOfWork unitOfWork,
            IMasterlistService masterlistService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _masterlistService = masterlistService;
            _mapper = mapper;
        }

        public async Task<List<MasterlistAdultDto>> Handle(GetMasterlistAdultRequest request, CancellationToken cancellationToken)
        {
            var adults = await _masterlistService.GetMasterlistAdults(request.HouseholdNo);
            var adultListDto = _mapper.Map<List<MasterlistAdultDto>>(adults);

            return adultListDto;
        }
    }
}
