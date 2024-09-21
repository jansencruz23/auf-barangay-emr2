using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.DTOs.Masterlist;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdolescent
{
    public class GetMasterlistAdolescentRequestHandler : IRequestHandler<GetMasterlistAdolescentRequest, List<MasterlistChildDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMasterlistService _masterlistService;
        private readonly IMapper _mapper;

        public GetMasterlistAdolescentRequestHandler(
            IUnitOfWork unitOfWork,
            IMasterlistService masterlistService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _masterlistService = masterlistService;
            _mapper = mapper;
        }

        public async Task<List<MasterlistChildDto>> Handle(GetMasterlistAdolescentRequest request, CancellationToken cancellationToken)
        {
            var adolescents = await _masterlistService.GetMasterlistAdolescents(request.HouseholdNo);
            var adolescentsListDto = _mapper.Map<List<MasterlistChildDto>>(adolescents);

            return adolescentsListDto;
        }
    }
}
