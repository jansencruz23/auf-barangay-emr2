using AUF.EMR2.Application.DTOs.WomanOfReproductiveAge;
using AUF.EMR2.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Commands.UpdateWra
{
    public record UpdateWraCommand : IRequest<BaseCommandResponse<int>>
    {
        public UpdateWraDto WraDto { get; set; }
    }
}
