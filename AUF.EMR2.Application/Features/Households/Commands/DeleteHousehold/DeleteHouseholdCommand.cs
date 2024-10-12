using AUF.EMR2.Application.Common.Responses;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;

public record DeleteHouseholdCommand(
    Guid Id
) : IRequest<ErrorOr<CommandResponse<Guid>>>;