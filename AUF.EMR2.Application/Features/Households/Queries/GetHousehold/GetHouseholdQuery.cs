using AUF.EMR2.Application.Features.Households.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHousehold;

public record GetHouseholdQuery : IRequest<ErrorOr<HouseholdQueryResponse>>
{
    public Guid Id { get; set; }
}
