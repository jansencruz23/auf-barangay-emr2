﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.HouseholdMember
{
    public class HouseholdMemberOnlyDto
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MotherMaidenName { get; set; }
        public char Sex { get; set; }
        public DateTime Birthday { get; set; }
        public Guid HouseholdId { get; set; }
        public string? NameOfMother { get; set; }
        public string? NameOfFather { get; set; }
        public bool IsNhts { get; set; }
    }
}
