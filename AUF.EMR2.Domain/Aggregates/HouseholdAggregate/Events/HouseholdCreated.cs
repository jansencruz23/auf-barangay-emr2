using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Events;

public record HouseholdCreated(Household Household) : IDomainEvent;