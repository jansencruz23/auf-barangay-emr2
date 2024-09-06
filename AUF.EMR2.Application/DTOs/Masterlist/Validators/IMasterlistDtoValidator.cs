using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.Masterlist.Validators
{
    public class IMasterlistDtoValidator : AbstractValidator<IMasterlistDto>
    {
        public IMasterlistDtoValidator()
        {
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
}
