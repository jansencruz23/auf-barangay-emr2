using AUF.EMR2.Application.Common.Models.Pagination;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.Households.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList;

public record GetHouseholdListQuery : IRequest<ErrorOr<PagedQueryResponse<HouseholdQueryResponse>>>
{
    public RequestParams RequestParams { get; set; } = null!;
    public string Query { get; set; } = null!;
}
