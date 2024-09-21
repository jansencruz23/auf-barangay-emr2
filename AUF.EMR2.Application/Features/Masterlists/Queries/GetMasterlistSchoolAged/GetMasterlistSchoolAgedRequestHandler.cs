using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Constants;
using AUF.EMR2.Application.DTOs.Masterlist;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSchoolAged
{
    public class GetMasterlistSchoolAgedRequestHandler : IRequestHandler<GetMasterlistSchoolAgedRequest, List<MasterlistChildDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMasterlistService _masterlistService;
        private readonly IMapper _mapper;

        public GetMasterlistSchoolAgedRequestHandler(
            IUnitOfWork unitOfWork,
            IMasterlistService masterlistService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _masterlistService = masterlistService;
            _mapper = mapper;
        }

        public async Task<List<MasterlistChildDto>> Handle(GetMasterlistSchoolAgedRequest request, CancellationToken cancellationToken)
        {
            var schoolAgedChildren = await _masterlistService.GetMasterlistSchoolAgedChildren(request.HouseholdNo);
            var schoolAgedListDto = _mapper.Map<List<MasterlistChildDto>>(schoolAgedChildren);

            return schoolAgedListDto;
        }
    }
}
