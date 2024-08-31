using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.HouseholdMember.Validators
{
    public class UpdateHouseholdMemberValidator : AbstractValidator<UpdateHouseholdMemberDto>
    {
        public UpdateHouseholdMemberValidator(IUnitOfWork unitOfWork)
        {
            Include(new IHouseholdMemberValidator(unitOfWork));
        }
    }
}
