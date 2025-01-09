using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.Masterlists.Commands.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistChild;

public sealed record UpdateMasterlistChildCommand(
    Guid Id,
    Guid Version,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    Sex Sex,
    DateTime Birthday,
    string? NameOfMother,
    string? NameOfFather,
    bool IsNhts,
    bool? IsInSchool
) : IRequest<ErrorOr<CommandResponse<Guid>>>, IUpdateMasterlistCommand;