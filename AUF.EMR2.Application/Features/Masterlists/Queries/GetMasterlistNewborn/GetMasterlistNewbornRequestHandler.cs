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

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistNewborn
{
    public class GetMasterlistNewbornRequestHandler : IRequestHandler<GetMasterlistNewbornRequest, List<MasterlistChildDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMasterlistNewbornRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MasterlistChildDto>> Handle(GetMasterlistNewbornRequest request, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Today.AddDays(MasterlistAgeRange.NewbornStart);

            var infants = await _unitOfWork.MasterlistRepository.GetListQuery(request.HouseholdNo, startDate);
            var infantListDto = _mapper.Map<List<MasterlistChildDto>>(infants);

            return infantListDto;
        }
    }
}
