using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.DTOs.Household;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;

public class CreateHouseholdDtoValidator : AbstractValidator<CreateHouseholdCommand>
{
    public CreateHouseholdDtoValidator(IUnitOfWork unitOfWork)
    {
        
        RuleFor(q => q.HouseholdNo)
            .MustAsync(async (householdNo, token) =>
            {
                return await unitOfWork.HouseholdRepository.IsHouseholdNoAvailable(householdNo);
            })
            .WithMessage("{PropertyName} is already existing.");
    }
}
