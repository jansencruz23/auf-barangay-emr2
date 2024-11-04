using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.WomanOfReproductiveAge;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Queries.GetPrintWraRecords
{
    public class GetPrintWraRecordsRequestHandler : IRequestHandler<GetPrintWraRecordsRequest, PrintWraDto>
    {
        private readonly int MONTHS_IN_QUARTER = 3;
        private readonly int FIRST_MONTH = 1;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPrintWraRecordsRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PrintWraDto> Handle(GetPrintWraRecordsRequest request, CancellationToken cancellationToken)
        {
            var dto = new PrintWraDto();

            var wras = await _unitOfWork.WraRepository.GetWraList(request.HouseholdNo);
            var address = await _unitOfWork.HouseholdRepository.GetFullAddress(request.HouseholdNo);
            var quarter = (DateTime.Now.Month - FIRST_MONTH) / MONTHS_IN_QUARTER + 1;

            dto.Quarter = $"Q{quarter} / {DateTime.Now.Year}";
            dto.DatePrepared = DateTime.Now.ToString("MMM dd, yyyy");
            dto.Wras = _mapper.Map<List<WraOnlyDto>>(wras);
            dto.Address = address;

            return dto;
        }
    }
}
