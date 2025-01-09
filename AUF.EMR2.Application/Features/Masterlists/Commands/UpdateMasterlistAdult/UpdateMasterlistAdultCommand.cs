using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistAdult;

public sealed record UpdateMasterlistAdultCommand(
    Guid Id,
    Guid Version,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    Sex Sex,
    DateTime Birthday,
    Guid HouseholdId,
    bool IsNhts 
) : IRequest<ErrorOr<CommandResponse<Guid>>>;