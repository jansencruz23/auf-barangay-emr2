using ErrorOr;

namespace AUF.EMR2.Domain.Common.Errors;

public partial class Errors
{
    public static class PregnancyTrackingHh
    {
        public static Error NotFound => Error.NotFound(
            code: "PregnancyTrackingHh.NotFound",
            description: "PregnancyTrackingHh was not found.");
    }
}
