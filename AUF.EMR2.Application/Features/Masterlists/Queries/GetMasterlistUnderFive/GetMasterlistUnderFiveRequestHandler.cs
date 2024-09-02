using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Constants;
using AUF.EMR2.Application.DTOs.Masterlist;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetMasterlistUnderFiveRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MasterlistChildDto>> Handle(GetMasterlistUnderFiveRequest request, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveEnd);

            var schoolAgedChildren = await _unitOfWork.MasterlistRepository.GetListQuery(request.HouseholdNo, startDate, endDate);
            var schoolAgedListDto = _mapper.Map<List<MasterlistChildDto>>(schoolAgedChildren);

            return schoolAgedListDto;
        }
    }
}
