using ErrorOr;

namespace AUF.EMR2.Domain.Common.Errors;

public static partial class Errors
{
    public static partial class Household
    {
        public static Error DuplicateHouseholdNo => Error.Conflict(
            code: "Household.DuplicateHouseholdNo",
            description: "Household no. is already existing.");

        public static Error EmptyHouseholdNo => Error.Validation(
            code: "Household.EmptyHouseholdNo",
            description: "Household no. cannot be empty.");

        public static Error NotFound => Error.NotFound(
            code: "Household.NotFound",
            description: "Household cannot be found.");
    }
}