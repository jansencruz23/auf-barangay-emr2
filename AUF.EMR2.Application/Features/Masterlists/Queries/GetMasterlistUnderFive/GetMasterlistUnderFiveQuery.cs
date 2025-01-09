using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistUnderFive;

public sealed record GetMasterlistUnderFiveQuery(
    Guid HouseholdId
) : IRequest<ErrorOr<List<MasterlistChildQueryResponse>>>, IMasterlistQuery;