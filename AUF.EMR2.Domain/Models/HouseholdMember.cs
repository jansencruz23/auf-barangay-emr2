using AUF.EMR2.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Models
{
    public class HouseholdMember : BaseDomainEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MotherMaidenName { get; set; }
        public int RelationshipToHouseholdHead { get; set; }
        public string? OtherRelation { get; set; }
        public char Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string? FirstQtrClassification { get; set; }
        public string? SecondQtrClassification { get; set; }
        public string? ThirdQtrClassification { get; set; }
        public string? FourthQtrClassification { get; set; }
        public string? Remarks { get; set; }
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
        public string? NameOfMother { get; set; }
        public string? NameOfFather { get; set; }
        public bool IsNhts { get; set; }
        public bool? IsInSchool { get; set; }
    }
}
