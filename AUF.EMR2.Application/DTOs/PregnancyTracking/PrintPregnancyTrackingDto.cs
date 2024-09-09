using AUF.EMR2.Application.DTOs.PregnancyTrackingHh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.PregnancyTracking
{
    public class PrintPregnancyTrackingDto
    {
        public PregnancyTrackingHhOnlyDto PregnancyTrackingHh { get; set; }
        public List<PregnancyTrackingDto> PregnancyTrackingList { get; set; }
    }
}
