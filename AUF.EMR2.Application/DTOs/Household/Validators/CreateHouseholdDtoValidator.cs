using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;

namespace AUF.EMR2.Application.DTOs.Household.Validators
{
    public class CreateHouseholdDtoValidator : AbstractValidator<CreateHouseholdDto>
    {
        public CreateHouseholdDtoValidator(IUnitOfWork unitOfWork)
        {
            Include(new IHouseholdDtoValidator());

            RuleFor(q => q.HouseholdNo)
                .MustAsync(async (householdNo, token) =>
                {
                    return await unitOfWork.HouseholdRepository.IsHouseholdNoAvailable(householdNo);
                })
                .WithMessage("{PropertyName} is already existing.");
        }
    }
}
