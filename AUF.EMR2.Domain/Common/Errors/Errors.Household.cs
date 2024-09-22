using ErrorOr;

namespace AUF.EMR2.Domain.Common.Errors;

public static class Errors
{
    public static partial class Household
    {
        public static Error DuplicateHouseholdNo => Error.Conflict(
            code: "Household.DuplicateHouseholdNo",
            description: "Household no. is already existing.");
    }
}