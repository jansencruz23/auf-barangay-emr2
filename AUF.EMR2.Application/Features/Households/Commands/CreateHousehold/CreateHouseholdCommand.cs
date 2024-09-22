using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Household;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;

public sealed record CreateHouseholdCommand(
    CreateHouseholdDto HouseholdDto
) : IRequest<ErrorOr<BaseCommandResponse<Guid>>>;
