using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;

public class DeleteHouseholdCommandValidator : AbstractValidator<DeleteHouseholdCommand>
{
    public DeleteHouseholdCommandValidator()
    {
        RuleFor(household => household.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
    }
}
