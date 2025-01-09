using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Commands.Common;

public sealed class IUpdateMasterlistCommandValidator : AbstractValidator<IUpdateMasterlistCommand>
{
    public IUpdateMasterlistCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(q => q.FirstName)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(q => q.LastName)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(q => q.Sex)
            .NotNull().WithMessage("{PropertyName} is required.");

        RuleFor(q => q.Birthday)
            .NotNull().WithMessage("{PropertyName} is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must be a date in the past or today.");

        RuleFor(q => q.IsNhts)
            .NotNull().WithMessage("{PropertyName} is required.");
    }
}
