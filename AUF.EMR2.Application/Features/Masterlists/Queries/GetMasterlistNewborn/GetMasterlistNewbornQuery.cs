using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistNewborn;

public sealed record GetMasterlistNewbornQuery(
    Guid HouseholdId
) : IRequest<ErrorOr<List<MasterlistChildQueryResponse>>>;