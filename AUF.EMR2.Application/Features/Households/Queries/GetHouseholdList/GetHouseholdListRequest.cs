using AUF.EMR2.Application.Common.Models.Pagination;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Household;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList
{
    public record GetHouseholdListRequest : IRequest<PagedQueryResponse<HouseholdDto>>
    {
        public RequestParams RequestParams { get; set; }
        public string Query { get; set; }
    }
}
