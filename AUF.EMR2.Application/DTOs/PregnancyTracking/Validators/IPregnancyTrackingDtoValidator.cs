using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.PregnancyTracking.Validators
{
    public class IPregnancyTrackingDtoValidator : AbstractValidator<IPregnancyTrackingDto>
    {
        public IPregnancyTrackingDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(q => q.Age)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.Gravidity)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.Parity)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.ExpectedDateOfDelivery)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(q => q.HouseholdMemberId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    return await unitOfWork.HouseholdMemberRepository.IsWraMember(id);
                })
                .WithMessage("{PropertyName} must exist and be a woman of reproductive age.");
        }
    }
}
