using ErrorOr;

namespace AUF.EMR2.Domain.Common.Errors;

public partial class Errors
{
    public static Error ConcurrentIssue => Error.Conflict(
        code: "Entity.ConcurrentIssue",
        description: "Entity is modified by another user.");
}

