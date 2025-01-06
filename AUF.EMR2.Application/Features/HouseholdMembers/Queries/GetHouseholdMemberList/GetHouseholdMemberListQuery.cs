using AUF.EMR2.Application.Features.HouseholdMembers.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMemberList;

public sealed record GetHouseholdMemberListQuery (
  Guid HouseholdId  
) : IRequest<ErrorOr<List<HouseholdMemberQueryResponse>>>;