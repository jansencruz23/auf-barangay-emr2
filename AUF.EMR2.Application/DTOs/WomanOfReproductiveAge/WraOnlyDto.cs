﻿using AUF.EMR2.Application.DTOs.HouseholdMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.WomanOfReproductiveAge
{
    public class WraOnlyDto : IWraDto
    {
        public Guid Id { get; set; }
        public Guid HouseholdMemberId { get; set; }
        public HouseholdMemberOnlyDto HouseholdMember { get; set; }
        public int CivilStatus { get; set; }
        public bool IsPlanningChildren { get; set; }
        public bool? IsPlanChildrenNow { get; set; }
        public bool? IsPlanChildrenSpacing { get; set; }
        public bool? IsPlanChildrenLimiting { get; set; }
        public bool IsFecund { get; set; }
        public bool IsFPMethod { get; set; }
        public bool? IsFPModern { get; set; }
        public bool? ShiftToModern { get; set; }
        public bool IsMFPUnmet { get; set; }
        public bool AcceptModernFpMethod { get; set; }
        public string? ModernFPMethod { get; set; }
        public DateTime? FPAcceptedDate { get; set; }
    }
}
