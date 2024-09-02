using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.OralHealth.Validators
{
    public class UpdateOralHealthDtoValidator : AbstractValidator<UpdateOralHealthDto>
    {
        public UpdateOralHealthDtoValidator()
        {
            Include(new IOralHealthDtoValidator());
        }
    }
}
