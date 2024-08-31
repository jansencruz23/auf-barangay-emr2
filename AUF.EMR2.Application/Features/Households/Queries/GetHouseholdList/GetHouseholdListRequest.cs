using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.Models.Pagination;
using AUF.EMR2.Application.Responses;
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
