using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.WomanOfReproductiveAge
{
    public class PrintWraDto
    {
        public string Barangay { get; set; }
        public string Address { get; set; }
        public string Quarter { get; set; }
        public string BhsMidwife { get; set; }
        public string DatePrepared { get; set; }
        public List<WraOnlyDto> Wras { get; set; }
    }
}
