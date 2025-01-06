using ErrorOr;

namespace AUF.EMR2.Domain.Common.Errors;

public static partial class Errors
{
    public static class Household
    {
        public static Error DuplicateHouseholdNo => Error.Conflict(
            code: "Household.DuplicateHouseholdNo",
            description: "Household no. is already existing.");

        public static Error EmptyHouseholdNo => Error.Validation(
            code: "Household.EmptyHouseholdNo",
            description: "Household no. cannot be empty.");

        public static Error NotFound => Error.NotFound(
            code: "Household.NotFound",
            description: "Household was not found.");

        public static Error FailedToCreate => Error.Failure(
            code: "Household.FailedToCreate",
            description: "Failed to create a household.");

        public static Error FailedToFetch => Error.Failure(
            code: "Household.FailedToFetch",
            description: "Failed to fetch a household.");
    }
}