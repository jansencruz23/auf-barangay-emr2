using AUF.EMR2.Application.Features.HouseholdMembers.Commands.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.UpdateHouseholdMember;

public sealed class UpdateHouseholdMemberCommandValidator : AbstractValidator<UpdateHouseholdMemberCommand>
{
    public UpdateHouseholdMemberCommandValidator()
    {
        Include(new IHouseholdMemberCommandValidator());

        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
    }
}
