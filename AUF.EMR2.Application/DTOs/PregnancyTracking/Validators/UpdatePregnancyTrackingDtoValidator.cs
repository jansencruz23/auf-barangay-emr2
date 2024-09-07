using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.PregnancyTracking.Validators
{
    public class UpdatePregnancyTrackingDtoValidator : AbstractValidator<UpdatePregnancyTrackingDto>
    {
        public UpdatePregnancyTrackingDtoValidator(IUnitOfWork unitOfWork)
        {
            Include(new IPregnancyTrackingDtoValidator(unitOfWork));
        }
    }
}
