﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.Barangay.Validators
{
    public class UpdateBarangayDtoValidator : AbstractValidator<UpdateBarangayDto>
    {
        public UpdateBarangayDtoValidator()
        {
            Include(new IBarangayDtoValidator());
        }
    }
}
