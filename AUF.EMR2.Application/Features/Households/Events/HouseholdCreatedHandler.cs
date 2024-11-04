using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Events;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Events;

public sealed class HouseholdCreatedHandler(IUnitOfWork unitOfWork) : INotificationHandler<HouseholdCreated>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(HouseholdCreated notification, CancellationToken cancellationToken)
    {
        var householdId = HouseholdId.Create(notification.Household.Id.Value);
        var pregTrackHh = PregnancyTrackingHh.Create
        (
            year: DateTime.Now.Year,
            birthingCenter: "Birthing Center",
            birthingCenterAddress: "Address ng bc",
            referralCenter: "Referral",
            referralCenterAddress: "Ref address",
            bwhName: "DK",
            midwifeName: "mid",
            householdId: householdId
        );

        await _unitOfWork.PregnancyTrackingHhRepository.Add(pregTrackHh);
        await _unitOfWork.SaveAsync();
    }
}
