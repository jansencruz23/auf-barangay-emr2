using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.Masterlist.Validators
{
    public class UpdateMasterlistChildDtoValidator : AbstractValidator<UpdateMasterlistChildDto>
    {
        public UpdateMasterlistChildDtoValidator()
        {
            Include(new IMasterlistDtoValidator());
        }
    }
}
