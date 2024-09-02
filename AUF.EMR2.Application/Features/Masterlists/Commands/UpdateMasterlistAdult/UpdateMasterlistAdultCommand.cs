﻿using AUF.EMR2.Application.DTOs.Masterlist;
using AUF.EMR2.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistAdult
{
    public record UpdateMasterlistAdultCommand : IRequest<BaseCommandResponse<int>>
    {
        public UpdateMasterlistAdultDto MasterlistDto { get; set; }
    }
}