using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.Common;
using AUF.EMR2.Application.Features.HouseholdMembers.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.UpdateHouseholdMember;

public sealed record UpdateHouseholdMemberCommand(
    Guid Id,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    RelationshipToHouseholdHead RelationshipToHouseholdHead,
    string? OtherRelation,
    Sex Sex,
    DateTime Birthday,
    QuarterlyClassificationData? QuarterlyClassification,
    string? Remarks,
    string? NameOfMother,
    string? NameOfFather,
    bool IsNhts,
    bool? IsInSchool,
    Guid Version
) : IRequest<ErrorOr<CommandResponse<Guid>>>, IHouseholdMemberCommand;