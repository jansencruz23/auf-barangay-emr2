using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.HouseholdMember
{
    public class UpdateHouseholdMemberDto : CreateHouseholdMemberDto
    {
        public int Id { get; set; }
        public Guid Version { get; set; }
    }
}
