using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.Household
{
    public class UpdateHouseholdDto : CreateHouseholdDto
    {
        public Guid Id { get; set; }
        public Guid Version { get; set; }
    }
}
