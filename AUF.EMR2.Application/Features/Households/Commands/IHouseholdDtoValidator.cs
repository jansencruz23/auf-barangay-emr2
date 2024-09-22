using AUF.EMR2.Application.DTOs.Household;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Commands;

public class IHouseholdDtoValidator : AbstractValidator<IHouseholdDto>
{
    public IHouseholdDtoValidator()
    {
        //RuleFor(q => q.HouseholdNo)
        //    .NotNull().WithMessage("{PropertyName} is required.");

        //RuleFor(q => q.FirstName)
        //    .NotNull().WithMessage("{PropertyName} is required.")
        //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        //RuleFor(q => q.LastName)
        //    .NotNull().WithMessage("{PropertyName} is required.")
        //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        //RuleFor(q => q.HouseNoAndStreet)
        //    .NotNull().WithMessage("{PropertyName} is required.");

        //RuleFor(q => q.Barangay)
        //    .NotNull().WithMessage("{PropertyName} is required.")
        //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        //RuleFor(q => q.City)
        //    .NotNull().WithMessage("{PropertyName} is required.")
        //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        //RuleFor(q => q.Province)
        //    .NotNull().WithMessage("{PropertyName} is required.")
        //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        //RuleFor(q => q.ContactNo)
        //    .NotNull().WithMessage("{PropertyName} is required.")
        //    .MaximumLength(11).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
        //    .MinimumLength(11).WithMessage("{PropertyName} must not be below {MinLength} characters.")
        //    .Matches("^[0-9]*$").WithMessage("{PropertyName} must be numeral digits.");
    }
}
