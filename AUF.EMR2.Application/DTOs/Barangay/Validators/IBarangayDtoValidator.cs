using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.Barangay.Validators
{
    public class IBarangayDtoValidator : AbstractValidator<IBarangayDto>
    {
        public IBarangayDtoValidator()
        {
            RuleFor(q => q.BarangayName)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.Street)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.Municipality)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.Province)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.Region)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.ContactNo)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(11).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
                .MinimumLength(11).WithMessage("{PropertyName} must not be below {MinLength} characters.")
                .Matches("^[0-9]*$").WithMessage("{PropertyName} must be numeral digits.");

            RuleFor(q => q.BarangayHealthStation)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.RuralHealthUnit)
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
