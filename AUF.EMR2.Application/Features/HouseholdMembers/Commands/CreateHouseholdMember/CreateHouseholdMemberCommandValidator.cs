using AUF.EMR2.Application.Features.HouseholdMembers.Commands.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.CreateHouseholdMember;

public class CreateHouseholdMemberCommandValidator : AbstractValidator<CreateHouseholdMemberCommand>
{
    public CreateHouseholdMemberCommandValidator()
    {
        Include(new IHouseholdMemberCommandValidator());

        RuleFor(x => x.HouseholdId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.");
    }
}
