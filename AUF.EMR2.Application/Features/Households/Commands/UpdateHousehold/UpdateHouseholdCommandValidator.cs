﻿using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Features.Households.Commands.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Households.Commands.UpdateHousehold;

public class UpdateHouseholdCommandValidator : AbstractValidator<UpdateHouseholdCommand>
{
    public UpdateHouseholdCommandValidator(IUnitOfWork unitOfWork)
    {
        Include(new IHouseholdCommandValidator());

        RuleFor(q => q.Id)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(q => q.HouseholdNo)
           .MustAsync(async (command, householdNo, token) =>
           {
               var existingHousehold = await unitOfWork.HouseholdRepository.Get(HouseholdId.Create(command.Id));
               if (existingHousehold != null! && existingHousehold.HouseholdNo.Equals(householdNo))
               {
                   return true;
               }

               return await unitOfWork.HouseholdRepository.IsHouseholdNoAvailable(householdNo);
           })
           .WithMessage("{PropertyName} is already existing.");
    }
}