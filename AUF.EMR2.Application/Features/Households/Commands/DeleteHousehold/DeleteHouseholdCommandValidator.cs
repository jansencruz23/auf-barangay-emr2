using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;

public class DeleteHouseholdCommandValidator : AbstractValidator<DeleteHouseholdCommand>
{
    public DeleteHouseholdCommandValidator()
    {
        RuleFor(q => q.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
    }
}
