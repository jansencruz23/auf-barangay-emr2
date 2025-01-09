using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdolescent;

public sealed record GetMasterlistAdolescentQuery(
    Guid HouseholdId
) : IRequest<ErrorOr<List<MasterlistChildQueryResponse>>>, IMasterlistQuery;