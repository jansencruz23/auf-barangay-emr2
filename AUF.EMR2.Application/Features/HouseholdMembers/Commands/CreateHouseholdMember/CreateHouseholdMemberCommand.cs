using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.Common;
using AUF.EMR2.Application.Features.HouseholdMembers.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.CreateHouseholdMember;

public record CreateHouseholdMemberCommand(
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    RelationshipToHouseholdHead RelationshipToHouseholdHead,
    string? OtherRelation,
    Sex Sex,
    DateTime Birthday,
    QuarterlyClassificationData? QuarterlyClassification,
    string? Remarks,
    Guid HouseholdId,
    string? NameOfMother,
    string? NameOfFather,
    bool IsNhts,
    bool? IsInSchool
) : IRequest<ErrorOr<CommandResponse<Guid>>>, IHouseholdMemberCommand;