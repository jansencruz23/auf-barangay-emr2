using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Masterlist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistAdult
{
    public record UpdateMasterlistAdultCommand : IRequest<BaseCommandResponse<Guid>>
    {
        public UpdateMasterlistAdultDto MasterlistDto { get; set; }
    }
}
