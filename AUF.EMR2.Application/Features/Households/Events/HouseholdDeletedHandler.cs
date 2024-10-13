using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Events;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Events;

public sealed class HouseholdDeletedHandler(IUnitOfWork unitOfWork) : INotificationHandler<HouseholdDeleted>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(HouseholdDeleted notification, CancellationToken cancellationToken)
    {
        var pregTrackHh = await _unitOfWork.PregnancyTrackingHhRepository
            .GetPregnancyTrackingHh(notification.HouseholdId);

        using var transaction = await _unitOfWork.BeginTransactionAsync();
        try
        {
            pregTrackHh.Delete();
            _unitOfWork.PregnancyTrackingHhRepository.Update(pregTrackHh);

            await _unitOfWork.SaveAsync();
            await transaction.CommitAsync(cancellationToken);
        }
        catch(Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
        }
    }
}
