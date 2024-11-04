using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.DTOs.Barangay
{
    public class BarangayDto : IBarangayDto
    {
        public Guid Id { get; set; }
        public string BarangayName { get; set; }
        public byte[]? Logo { get; set; }
        public string Street { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string Region { get; set; }
        public string ContactNo { get; set; }
        public string BarangayHealthStation { get; set; }
        public string RuralHealthUnit { get; set; }
        public string? Description { get; set; }
        public Guid Version { get; set; }
    }
}
