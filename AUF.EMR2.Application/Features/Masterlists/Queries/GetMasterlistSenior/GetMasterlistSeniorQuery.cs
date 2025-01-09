using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSenior;

public sealed record GetMasterlistSeniorQuery(
    Guid HouseholdId
) : IRequest<ErrorOr<List<MasterlistAdultQueryResponse>>>, IMasterlistQuery;