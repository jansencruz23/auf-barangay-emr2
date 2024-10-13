using FluentValidation;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh;

public class GetPregnancyTrackingHhQueryValidator : AbstractValidator<GetPregnancyTrackingHhQuery>
{
    public GetPregnancyTrackingHhQueryValidator()
    {
        RuleFor(pregTrachHh => pregTrachHh.HouseholdId)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
    }
}
