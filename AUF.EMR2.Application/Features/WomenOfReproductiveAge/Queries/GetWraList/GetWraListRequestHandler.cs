using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.DTOs.WomanOfReproductiveAge;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Queries.GetWraList
{
    public class GetWraListRequestHandler : IRequestHandler<GetWraListRequest, List<WraOnlyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetWraListRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<WraOnlyDto>> Handle(GetWraListRequest request, CancellationToken cancellationToken)
        {
            var wras = await _unitOfWork.WraRepository.GetWraList(request.HouseholdNo);
            var wraListDto = _mapper.Map<List<WraOnlyDto>>(wras);

            return wraListDto;
        }
    }
}
