using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdult;

public sealed record GetMasterlistAdultQuery(
    Guid HouseholdId
) : IRequest<ErrorOr<List<MasterlistAdultQueryResponse>>>, IMasterlistQuery;