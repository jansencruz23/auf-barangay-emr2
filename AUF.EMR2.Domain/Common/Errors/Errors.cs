using ErrorOr;

namespace AUF.EMR2.Domain.Common.Errors;

public static partial class Errors
{
    public static Error ConcurrentIssue => Error.Conflict(
        code: "Entity.ConcurrentIssue",
        description: "Entity is modified by another user.");

    public static Error NotFound => Error.NotFound(
        code: "Household.NotFound",
        description: "Entity cannot be found.");

    public static Error FailedToCreate => Error.Failure(
        code: "Household.FailedToCreate",
        description: "Failed to create an entity.");

    public static Error FailedToFetch => Error.Failure(
        code: "Household.FailedToFetch",
        description: "Failed to fetch an entity.");
    public static Error FailedToUpdate => Error.Failure(
        code: "Household.FailedToUpdate",
        description: "Failed to update an entity.");

    public static Error FailedToDelete => Error.Failure(
        code: "Household.FailedToDelete",
        description: "Failed to delete an entity.");
}

