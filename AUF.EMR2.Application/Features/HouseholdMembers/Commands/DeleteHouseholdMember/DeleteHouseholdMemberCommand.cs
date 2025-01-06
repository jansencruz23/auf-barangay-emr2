using AUF.EMR2.Application.Common.Responses;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.DeleteHouseholdMember;

public sealed record DeleteHouseholdMemberCommand(
    Guid Id
): IRequest<ErrorOr<CommandResponse<Guid>>>;