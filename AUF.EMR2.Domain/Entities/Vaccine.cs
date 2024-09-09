﻿using AUF.EMR2.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Entities
{
    public class Vaccine : BaseDomainEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<AdministeredVaccine> AdministeredVaccines { get; set; }
    }
}
