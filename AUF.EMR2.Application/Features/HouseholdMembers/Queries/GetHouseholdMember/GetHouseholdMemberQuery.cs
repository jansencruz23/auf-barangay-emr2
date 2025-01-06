using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMember;

public sealed record GetHouseholdMemberQuery(
    Guid Id
) : IRequest<ErrorOr<HouseholdMemberQueryResponse>>;