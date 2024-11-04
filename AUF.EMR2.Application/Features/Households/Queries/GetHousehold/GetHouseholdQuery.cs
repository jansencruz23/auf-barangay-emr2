using AUF.EMR2.Application.Features.Households.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHousehold;

public record GetHouseholdQuery(
    Guid Id
) : IRequest<ErrorOr<HouseholdQueryResponse>>;