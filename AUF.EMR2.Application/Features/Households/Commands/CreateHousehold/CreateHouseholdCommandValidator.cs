using AUF.EMR2.Application.Features.Households.Commands.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;

public class CreateHouseholdCommandValidator : AbstractValidator<CreateHouseholdCommand>
{
    public CreateHouseholdCommandValidator()
    {
        Include(new IHouseholdCommandValidator());

        RuleFor(q => q.HouseholdNo)
            .NotNull()
            .NotEmpty();
    }
}
