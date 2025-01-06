using FluentValidation;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.DeleteHouseholdMember;

public sealed class DeleteHouseholdMemberCommandValidator : AbstractValidator<DeleteHouseholdMemberCommand>
{
    public DeleteHouseholdMemberCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
    }
}
