using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.Events;

public sealed record HouseholdMemberDeleted(HouseholdMemberId HouseholdMemberId) : IDomainEvent;
