using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetWraHouseholdMemberList;

public sealed record GetWraHouseholdMemberListQuery(
    Guid HouseholdId    
) : IRequest<ErrorOr<List<HouseholdMemberQueryResponse>>>;