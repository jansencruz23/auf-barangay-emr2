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

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistInfant
{
    public class GetMasterlistInfantRequestHandler : IRequestHandler<GetMasterlistInfantRequest, List<MasterlistChildDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMasterlistService _masterlistService;
        private readonly IMapper _mapper;

        public GetMasterlistInfantRequestHandler(
            IUnitOfWork unitOfWork,
            IMasterlistService masterlistService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _masterlistService = masterlistService;
            _mapper = mapper;
        }

        public async Task<List<MasterlistChildDto>> Handle(GetMasterlistInfantRequest request, CancellationToken cancellationToken)
        {
            var infants = await _masterlistService.GetMasterlistInfants(request.HouseholdNo);
            var infantListDto = _mapper.Map<List<MasterlistChildDto>>(infants);

            return infantListDto;
        }
    }
}
