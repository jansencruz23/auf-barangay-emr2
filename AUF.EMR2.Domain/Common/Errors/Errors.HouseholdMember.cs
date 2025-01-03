using ErrorOr;

namespace AUF.EMR2.Domain.Common.Errors;

public static partial class Errors
{
    public static class HouseholdMember
    {
        public static Error NotFound => Error.Conflict(
            code: "HouseholdMember.NotFound",
            description: "Household Member was not found.");
    }
}
