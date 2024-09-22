using AUF.EMR2.Application.Common.Constants;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Commands.Common;

public class IHouseholdCommandValidator : AbstractValidator<IHouseholdCommand>
{
    public IHouseholdCommandValidator()
    {
        RuleFor(q => q.HouseholdNo)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.");

        RuleFor(q => q.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(HouseholdConstants.MaxNameLength).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(q => q.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(HouseholdConstants.MaxNameLength).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(q => q.HouseAddress.HouseNoAndStreet)
            .NotEmpty().WithMessage("House no. and street is required.")
            .NotNull().WithMessage("House no. and street is required.")
            .MaximumLength(HouseholdConstants.MaxAddressLength).WithMessage("Barangay must not exceed {MaxLength} characters.");

        RuleFor(q => q.HouseAddress.Barangay)
            .NotEmpty().WithMessage("Barangay is required.")
            .NotNull().WithMessage("Barangay is required.")
            .MaximumLength(HouseholdConstants.MaxAddressLength).WithMessage("Barangay must not exceed {MaxLength} characters.");

        RuleFor(q => q.HouseAddress.City)
            .NotEmpty().WithMessage("City is required.")
            .NotNull().WithMessage("City is required.")
            .MaximumLength(HouseholdConstants.MaxAddressLength).WithMessage("City must not exceed {MaxLength} characters.");

        RuleFor(q => q.HouseAddress.Province)
            .NotEmpty().WithMessage("Province is required.")
            .NotNull().WithMessage("Province is required.")
            .MaximumLength(HouseholdConstants.MaxAddressLength).WithMessage("Province must not exceed {MaxLength} characters.");

        RuleFor(q => q.ContactNo)
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(11).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .MinimumLength(11).WithMessage("{PropertyName} must not be below {MinLength} characters.")
            .Matches("^[0-9]*$").WithMessage("{PropertyName} must be numeral digits.");
    }
}
