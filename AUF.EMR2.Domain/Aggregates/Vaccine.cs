using AUF.EMR2.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Aggregates
{
    public class Vaccine 
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<AdministeredVaccine> AdministeredVaccines { get; set; }
    }
}
