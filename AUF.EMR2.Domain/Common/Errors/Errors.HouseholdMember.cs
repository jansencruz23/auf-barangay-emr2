using ErrorOr;

namespace AUF.EMR2.Domain.Common.Errors;

public static partial class Errors
{
    public static class HouseholdMember
    {
        public static Error NotFound => Error.NotFound(
            code: "HouseholdMember.NotFound",
            description: "Household Member was not found.");

        public static Error FailedToCreate => Error.Failure(
            code: "HouseholdMember.FailedToCreate",
            description: "Failed to create a household member.");

        public static Error FailedToFetch => Error.Failure(
            code: "HouseholdMember.FailedToFetch",
            description: "Failed to fetch a household member.");

        public static Error FailedToUpdate => Error.Failure(
            code: "HouseholdMember.FailedToUpdate",
            description: "Failed to update a household member.");

        public static Error FailedToDelete => Error.Failure(
            code: "HouseholdMember.FailedToDelete",
            description: "Failed to delete a household member.");
    }
}
