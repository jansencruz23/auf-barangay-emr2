using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Queries.GetHouseholdByHouseholdNo;

public class GetHouseholdByHouseholdNoQueryValidator : AbstractValidator<GetHouseholdByHouseholdNoQuery>
{
    public GetHouseholdByHouseholdNoQueryValidator()
    {
        RuleFor(household => household.HouseholdNo)
            .NotNull()
            .NotEmpty().WithMessage("{PropertyName} must not be empty.");
    }
}
