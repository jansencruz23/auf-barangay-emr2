using AUF.EMR2.Application.DTOs.Barangay;
using AUF.EMR2.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay
{
    public record UpdateBarangayCommand : IRequest<BaseCommandResponse<int>>
    {
        public UpdateBarangayDto BarangayDto { get; set; }
    }
}
