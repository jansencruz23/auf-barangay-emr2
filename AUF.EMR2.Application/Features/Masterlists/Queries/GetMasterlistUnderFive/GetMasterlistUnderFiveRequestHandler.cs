using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;

using AUF.EMR2.Application.DTOs.Masterlist;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistUnderFive
{
    public class GetMasterlistUnderFiveRequestHandler : IRequestHandler<GetMasterlistUnderFiveRequest, List<MasterlistChildDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMasterlistService _masterlistService;
        private readonly IMapper _mapper;

        public GetMasterlistUnderFiveRequestHandler(
            IUnitOfWork unitOfWork,
            IMasterlistService masterlistService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _masterlistService = masterlistService;
            _mapper = mapper;
        }

        public async Task<List<MasterlistChildDto>> Handle(GetMasterlistUnderFiveRequest request, CancellationToken cancellationToken)
        {
            var schoolAgedChildren = await _masterlistService.GetMasterlistUnderFiveChildren(request.HouseholdNo);
            var schoolAgedListDto = _mapper.Map<List<MasterlistChildDto>>(schoolAgedChildren);

            return schoolAgedListDto;
        }
    }
}
