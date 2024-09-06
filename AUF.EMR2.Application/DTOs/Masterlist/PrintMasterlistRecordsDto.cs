using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.Masterlist
{
    public class PrintMasterlistRecordsDto
    {
        public string Barangay { get; set; }
        public string Midwife { get; set; }
        public string Address { get; set; }
        public List<MasterlistChildOnlyDto> Newborns { get; set; }
        public List<MasterlistChildOnlyDto> Infants { get; set; }
        public List<MasterlistChildOnlyDto> UnderFiveChildren { get; set; }
        public List<MasterlistChildOnlyDto> SchoolAgedChildren { get; set; }
        public List<MasterlistChildOnlyDto> Adolescents { get; set; }
        public List<MasterlistAdultOnlyDto> Adults { get; set; }
        public List<MasterlistAdultOnlyDto> Seniors { get; set; }
    }
}
