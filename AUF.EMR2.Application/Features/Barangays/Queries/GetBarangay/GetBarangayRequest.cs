using AUF.EMR2.Application.DTOs.Barangay;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Barangays.Queries.GetBarangay
{
    public record GetBarangayRequest : IRequest<BarangayDto>
    {
    }
}
