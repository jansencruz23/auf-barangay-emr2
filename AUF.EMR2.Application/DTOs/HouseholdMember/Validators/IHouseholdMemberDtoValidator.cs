using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.HouseholdMember.Validators
{
    public class IHouseholdMemberDtoValidator : AbstractValidator<IHouseholdMemberDto>
    {
        public IHouseholdMemberDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(q => q.FirstName)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.LastName)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.RelationshipToHouseholdHead)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be more than 0.")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} must be less than {ComparisonValue}.");

            RuleFor(q => q.Sex)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.Birthday)
                .NotNull().WithMessage("{PropertyName} is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must be a date in the past or today..");

            RuleFor(q => q.HouseholdId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .MustAsync(async (id, token) =>
                {
                    return await unitOfWork.HouseholdRepository.Exists(id);
                })
                .WithMessage("{PropertyName} must exist.");
        }
    }
}
