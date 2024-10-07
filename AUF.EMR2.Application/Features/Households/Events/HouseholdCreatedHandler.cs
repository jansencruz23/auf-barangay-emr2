using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Events;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Events;

public sealed class HouseholdCreatedHandler(IUnitOfWork unitOfWork) : INotificationHandler<HouseholdCreated>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public Task Handle(HouseholdCreated notification, CancellationToken cancellationToken)
    {
        
        throw new NotImplementedException();
    }
}
