using AUF.EMR2.Application.DTOs.Household;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.Masterlist
{
    public class MasterlistAdultDto : IMasterlistDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MotherMaidenName { get; set; }
        public char Sex { get; set; }
        public DateTime Birthday { get; set; }
        public int HouseholdId { get; set; }
        public HouseholdOnlyDto Household { get; set; }
        public bool IsNhts { get; set; }
        public Guid Version { get; set; }
    }
}
