using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.OralHealth
{
    public class PrintOralHealthDto
    {
        public string Address { get; set; }
        public List<OralHealthOnlyDto> Infants { get; set; }
        public List<OralHealthOnlyDto> OneToFourChildren { get; set; }
        public List<OralHealthOnlyDto> FiveToNineChildren { get; set; }
        public List<OralHealthOnlyDto> TenToFourteenChildren { get; set; }
        public List<OralHealthOnlyDto> PregnantFifteenToNineteen { get; set; }
        public List<OralHealthOnlyDto> PregnantTwentyToFourtyNine { get; set; }
    }
}
