using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.PregnancyTrackingHh.Validators
{
    public class IPregnancyTrackingHhDtoValidator : AbstractValidator<IPregnancyTrackingHhDto>
    {
        public IPregnancyTrackingHhDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(q => q.Year)
                .NotNull().WithMessage("{PropertyName} is required.");

            //RuleFor(q => q.BarangayId)
            //    .NotNull().WithMessage("{PropertyName} is required.")
            //    .NotEqual(Guid.Empty).WithMessage("{PropertyName} is required.")
            //    .MustAsync(async (id, token) =>
            //    {
            //        return await unitOfWork.BarangayRepository.Exists(id);
            //    })
            //    .WithMessage("{PropertyName} must exist.");

            //RuleFor(q => q.HouseholdId)
            //    .NotNull().WithMessage("{PropertyName} is required.")
            //    .NotEqual(Guid.Empty).WithMessage("{PropertyName} is required.")
            //    .MustAsync(async (id, token) =>
            //    {
            //        return await unitOfWork.HouseholdRepository.Exists(id);
            //    })
            //    .WithMessage("{PropertyName} must exist.");
        }
    }
}
