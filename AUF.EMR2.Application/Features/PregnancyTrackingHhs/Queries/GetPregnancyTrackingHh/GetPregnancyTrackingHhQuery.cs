using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh;

public record GetPregnancyTrackingHhQuery(
    Guid HouseholdId
) : IRequest<ErrorOr<GetPregnancyTrackingHhQueryResponse>>;