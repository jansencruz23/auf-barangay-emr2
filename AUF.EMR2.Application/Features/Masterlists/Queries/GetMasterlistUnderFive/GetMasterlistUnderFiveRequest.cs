using AUF.EMR2.Application.DTOs.Masterlist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistUnderFive
{
    public record GetMasterlistUnderFiveRequest : IRequest<List<MasterlistChildDto>>
    {
        public string HouseholdNo { get; set; }
    }
}
