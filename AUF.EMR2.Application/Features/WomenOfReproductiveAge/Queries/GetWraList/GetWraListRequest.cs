using AUF.EMR2.Application.DTOs.WomanOfReproductiveAge;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Queries.GetWraList
{
    public record GetWraListRequest : IRequest<List<WraOnlyDto>>
    {
        public string HouseholdNo { get; set; }
    }
}
