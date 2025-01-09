using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Enums;

namespace AUF.EMR2.Application.Features.Masterlists.Commands.Common;

public interface IUpdateMasterlistCommand
{
    public Guid Id { get; init; }
    public Guid Version { get; init; }
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public string? MotherMaidenName { get; init; }
    public Sex Sex { get; init; }
    public DateTime Birthday { get; init; }
    public bool IsNhts { get; init; }
}
