using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHousehold;

public class GetHouseholdQueryValidator : AbstractValidator<GetHouseholdQuery>
{
    public GetHouseholdQueryValidator()
    {
        RuleFor(household => household.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
    }
}
