using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.DTOs.WomanOfReproductiveAge;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Queries.GetWra
{
    public class GetWraRequestHandler : IRequestHandler<GetWraRequest, WraDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetWraRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WraDto> Handle(GetWraRequest request, CancellationToken cancellationToken)
        {
            var wra = await _unitOfWork.WraRepository.GetWra(request.Id);
            var wraDto = _mapper.Map<WraDto>(wra);

            return wraDto;
        }
    }
}
