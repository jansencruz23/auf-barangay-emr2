using AUF.EMR2.Application.Features.Households.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdByHouseholdNo;

public record GetHouseholdByHouseholdNoQuery : IRequest<ErrorOr<HouseholdQueryResponse>>
{
    public string HouseholdNo { get; set; } = null!;
}
