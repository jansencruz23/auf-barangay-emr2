using ErrorOr;

namespace AUF.EMR2.Domain.Common.Errors;

public static partial class Errors
{
    public static class Barangay
    {
        public static Error NotFound => Error.Conflict(
            code: "Barangay.NotFound",
            description: "Barangay is not found.");
    }
}

