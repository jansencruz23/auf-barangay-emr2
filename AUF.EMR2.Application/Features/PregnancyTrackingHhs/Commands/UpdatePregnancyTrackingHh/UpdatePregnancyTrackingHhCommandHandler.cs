using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using MapsterMapper;
using MediatR;
using ErrorOr;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Commands.UpdatePregnancyTrackingHh
{
    public class UpdatePregnancyTrackingHhCommandHandler : IRequestHandler<UpdatePregnancyTrackingHhCommand, ErrorOr<CommandResponse<Guid>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePregnancyTrackingHhCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<CommandResponse<Guid>>> Handle(UpdatePregnancyTrackingHhCommand request, CancellationToken cancellationToken)
        {
            var pregTrackHh = await _unitOfWork.PregnancyTrackingHhRepository
                .GetPregnancyTrackingHh(PregnancyTrackingHhId.Create(request.Id));

            if (pregTrackHh is null)
            {
                return Errors.PregnancyTrackingHh.NotFound;
            }

            var response = new CommandResponse<Guid>();

            pregTrackHh.Update(
                year: request.Year,
                birthingCenter: request.BirthingCenter,
                birthingCenterAddress: request.BirthingCenterAddress,
                referralCenter: request.ReferralCenter,
                referralCenterAddress: request.ReferralCenterAddress,
                bwhName: request.BhwName,
                midwifeName: request.MidwifeName
            );

            _unitOfWork.PregnancyTrackingHhRepository.Update(pregTrackHh);
            await _unitOfWork.SaveAsync();

            response.Success = true;
            response.Message = "Updation is successful";
            response.Id = pregTrackHh.Id.Value;

            return response;
        }
    }
}
