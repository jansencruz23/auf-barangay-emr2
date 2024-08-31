using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.HouseholdMember.Validators
{
    public class IHouseholdMemberValidator : AbstractValidator<IHouseholdMemberDto>
    {
        public IHouseholdMemberValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(q => q.FirstName)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.LastName)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(q => q.RelationshipToHouseholdHead)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .GreaterThan(0).WithMessage("{PropertyName} must be more than 0.")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} must be less than 6.");

            RuleFor(q => q.Sex)
                .NotNull().WithMessage("{PropertyName} must not be empty.");

            RuleFor(q => q.Birthday)
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must not be less than today.");

            RuleFor(q => q.HouseholdId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .MustAsync(async (id, token) =>
                {
                    return await unitOfWork.HouseholdRepository.Exists(id);
                })
                .WithMessage("{PropertyName} must exist.");
        }
    }
}
