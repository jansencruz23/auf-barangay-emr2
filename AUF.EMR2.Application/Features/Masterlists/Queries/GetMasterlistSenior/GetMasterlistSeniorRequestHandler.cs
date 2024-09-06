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

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSenior
{
    public class GetMasterlistSeniorRequestHandler : IRequestHandler<GetMasterlistSeniorRequest, List<MasterlistAdultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMasterlistService _masterlistService;
        private readonly IMapper _mapper;

        public GetMasterlistSeniorRequestHandler(
            IUnitOfWork unitOfWork,
            IMasterlistService masterlistService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _masterlistService = masterlistService;
            _mapper = mapper;
        }

        public async Task<List<MasterlistAdultDto>> Handle(GetMasterlistSeniorRequest request, CancellationToken cancellationToken)
        {
            var seniors = await _masterlistService.GetMasterlistSeniors(request.HouseholdNo);
            var seniorListDto = _mapper.Map<List<MasterlistAdultDto>>(seniors);

            return seniorListDto;
        }
    }
}
