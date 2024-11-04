using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Events;

public record HouseholdDeleted(HouseholdId HouseholdId) : IDomainEvent;