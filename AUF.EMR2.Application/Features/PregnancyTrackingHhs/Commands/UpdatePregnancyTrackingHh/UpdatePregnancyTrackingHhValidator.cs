using FluentValidation;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Commands.UpdatePregnancyTrackingHh;

public class UpdatePregnancyTrackingHhValidator : AbstractValidator<UpdatePregnancyTrackingHhCommand>
{
    public UpdatePregnancyTrackingHhValidator()
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

        RuleFor(q => q.HouseholdId)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} is required.");
    }
}
