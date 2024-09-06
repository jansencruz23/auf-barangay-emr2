using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.WomanOfReproductiveAge.Validators
{
    public class IWraDtoValidator : AbstractValidator<IWraDto>
    {
        public IWraDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(q => q.CivilStatus)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.IsPlanningChildren)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.IsFecund)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.IsFPMethod)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.IsMFPUnmet)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.AcceptModernFpMethod)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.FPAcceptedDate)
                .NotNull().WithMessage("{PropertyName} is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must be a date in the past or today.");

            RuleFor(q => q.HouseholdMemberId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .MustAsync(async (id, token) =>
                {
                    return await unitOfWork.HouseholdMemberRepository.IsWraMember(id);
                })
                .WithMessage("{PropertyName} must exist and be a woman of reproductive age.");
        }
    }
}
