using AUF.EMR2.Application.DTOs.Household;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Households.Commands.UpdateHousehold
{
    public class UpdateHouseholdDtoValidator : AbstractValidator<UpdateHouseholdDto>
    {
        public UpdateHouseholdDtoValidator()
        {
            Include(new IHouseholdDtoValidator());
        }
    }
}
