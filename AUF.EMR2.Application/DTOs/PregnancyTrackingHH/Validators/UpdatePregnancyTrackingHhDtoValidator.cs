using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.PregnancyTrackingHh.Validators
{
    public class UpdatePregnancyTrackingHhDtoValidator : AbstractValidator<UpdatePregnancyTrackingHhDto>
    {
        public UpdatePregnancyTrackingHhDtoValidator(IUnitOfWork unitOfWork)
        {
            Include(new IPregnancyTrackingHhDtoValidator(unitOfWork));
        }
    }
}
