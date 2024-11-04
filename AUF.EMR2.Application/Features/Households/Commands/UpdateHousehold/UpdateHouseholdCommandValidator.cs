using AUF.EMR2.Application.Features.Households.Commands.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Commands.UpdateHousehold;

public class UpdateHouseholdCommandValidator : AbstractValidator<UpdateHouseholdCommand>
{
    public UpdateHouseholdCommandValidator()
    {
        Include(new IHouseholdCommandValidator());

        RuleFor(household => household.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");

        RuleFor(household => household.HouseholdNo)
           .NotNull()
           .NotEmpty();
    }
}
