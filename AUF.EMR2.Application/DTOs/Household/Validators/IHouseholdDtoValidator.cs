using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.Household.Validators
{
    public class IHouseholdDtoValidator : AbstractValidator<IHouseholdDto>
    {
        public IHouseholdDtoValidator()
        {
            RuleFor(q => q.HouseholdNo)
                .NotNull().WithMessage("{PropertyName} must not be empty.");

            RuleFor(q => q.FirstName)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.LastName)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.HouseNoAndStreet)
                .NotNull().WithMessage("{PropertyName} must not be empty.");

            RuleFor(q => q.Barangay)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.City)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.Province)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.ContactNo)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(11).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
                .MinimumLength(11).WithMessage("{PropertyName} must not be below {MinLength} characters.")
                .Matches("^[0-9]*$").WithMessage("{PropertyName} must be numeral digits.");
        }
    }
}
