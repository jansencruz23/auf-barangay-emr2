﻿namespace AUF.EMR2.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : ValueObject
{
    protected AggregateRoot(TId id) : base(id) { }

    #pragma warning disable CS8618
    protected AggregateRoot() { }
    #pragma warning restore CS8618
}
