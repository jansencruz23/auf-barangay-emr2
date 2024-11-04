using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.WomanOfReproductiveAge;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Commands.UpdateWra
{
    public record UpdateWraCommand : IRequest<CommandResponse<Guid>>
    {
        public UpdateWraDto WraDto { get; set; }
    }
}
