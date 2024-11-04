using FluentValidation;

namespace AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay;

public sealed class UpdateBarangayCommandValidator : AbstractValidator<UpdateBarangayCommand>
{
    public UpdateBarangayCommandValidator()
    {
        RuleFor(brgy => brgy.BarangayName)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(brgy => brgy.Street)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(brgy => brgy.Municipality)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(brgy => brgy.Province)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(brgy => brgy.Region)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(brgy => brgy.ContactNo)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(11).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .MinimumLength(11).WithMessage("{PropertyName} must not be below {MinLength} characters.")
            .Matches("^[0-9]*$").WithMessage("{PropertyName} must be numeral digits.");

        RuleFor(brgy => brgy.BarangayHealthStation)
            .NotNull().WithMessage("{PropertyName} is required.");

        RuleFor(brgy => brgy.RuralHealthUnit)
            .NotNull().WithMessage("{PropertyName} is required.");
    }
}
