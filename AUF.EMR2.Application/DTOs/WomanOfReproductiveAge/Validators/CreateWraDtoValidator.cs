using AUF.EMR2.Application.Abstraction.Persistence.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.WomanOfReproductiveAge.Validators
{
    public class CreateWraDtoValidator : AbstractValidator<CreateWraDto>
    {
        public CreateWraDtoValidator(IUnitOfWork unitOfWork)
        {
            Include(new IWraDtoValidator(unitOfWork));
        }
    }
}
