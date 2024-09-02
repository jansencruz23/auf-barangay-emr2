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

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdult
{
    public class GetMasterlistAdultRequestHandler : IRequestHandler<GetMasterlistAdultRequest, List<MasterlistAdultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMasterlistAdultRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MasterlistAdultDto>> Handle(GetMasterlistAdultRequest request, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultEnd);

            var adults = await _unitOfWork.MasterlistRepository.GetListQuery(request.HouseholdNo, startDate, endDate);
            var adultListDto = _mapper.Map<List<MasterlistAdultDto>>(adults);

            return adultListDto;
        }
    }
}
