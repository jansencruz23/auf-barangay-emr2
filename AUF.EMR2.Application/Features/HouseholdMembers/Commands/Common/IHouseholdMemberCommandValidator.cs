using AUF.EMR2.Application.Common.Constants;
using FluentValidation;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.Common;

public sealed class IHouseholdMemberCommandValidator : AbstractValidator<IHouseholdMemberCommand>
{
    public IHouseholdMemberCommandValidator()
    {
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(TablePropertiesConstants.MaxNameLength).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(TablePropertiesConstants.MaxNameLength).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(x => x.RelationshipToHouseholdHead)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Sex)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.");
        
        RuleFor(x => x.Birthday)
            .NotNull().WithMessage("{PropertyName} is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must be a date in the past or today..");

        RuleFor(x => x.IsNhts)
            .NotNull().WithMessage("{PropertyName} is required.");
    }
}
