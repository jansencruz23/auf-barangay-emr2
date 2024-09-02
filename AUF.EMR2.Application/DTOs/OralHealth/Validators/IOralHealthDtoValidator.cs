using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.OralHealth.Validators
{
    public class IOralHealthDtoValidator : AbstractValidator<IOralHealthDto>
    {
        public IOralHealthDtoValidator()
        {
            RuleFor(q => q.FirstName)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.LastName)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.Sex)
                .NotNull().WithMessage("{PropertyName} must not be empty.");

            RuleFor(q => q.Birthday)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must not be less than today.");

            RuleFor(q => q.IsNhts)
                .NotNull().WithMessage("{PropertyName} must not be empty.");
        }
    }
}
