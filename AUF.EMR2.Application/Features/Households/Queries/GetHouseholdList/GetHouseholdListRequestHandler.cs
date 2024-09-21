using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Household;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList
{
    public class GetHouseholdListRequestHandler : IRequestHandler<GetHouseholdListRequest, PagedQueryResponse<HouseholdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHouseholdListRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedQueryResponse<HouseholdDto>> Handle(GetHouseholdListRequest request, CancellationToken cancellationToken)
        {
            var household = await _unitOfWork.HouseholdRepository.GetHouseholdList(request.RequestParams, request.Query);
            var householdDto = _mapper.Map<List<HouseholdDto>>(household);
            var totalCount = household.TotalItemCount;

            return new PagedQueryResponse<HouseholdDto> { Data = householdDto, TotalCount = totalCount };
        }
    }
}
