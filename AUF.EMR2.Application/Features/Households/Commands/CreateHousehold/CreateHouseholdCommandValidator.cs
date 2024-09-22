using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.Households.Commands.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;

public class CreateHouseholdCommandValidator : AbstractValidator<CreateHouseholdCommand>
{
    public CreateHouseholdCommandValidator(IUnitOfWork unitOfWork)
    {
        Include(new IHouseholdCommandValidator());

        RuleFor(q => q.HouseholdNo)
            .MustAsync(async (householdNo, token) =>
            {
                return await unitOfWork.HouseholdRepository.IsHouseholdNoAvailable(householdNo);
            })
            .WithMessage("{PropertyName} is already existing.");
    }
}
