using AUF.EMR2.Application.Common.Models.Pagination;
using AUF.EMR2.Application.Common.Responses;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList;

public record GetHouseholdListQuery : IRequest<ErrorOr<PagedQueryResponse<GetHouseholdListQueryResponse>>>
{
    public RequestParams RequestParams { get; set; } = null!;
    public string Query { get; set; } = null!;
}
