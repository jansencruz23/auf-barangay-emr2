using AUF.EMR2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Persistence.Configurations.Entities
{
    public class BarangayConfiguration : IEntityTypeConfiguration<Barangay>
    {
        public void Configure(EntityTypeBuilder<Barangay> builder)
        {
            builder.HasData(
                new Barangay
                {
                    Id = 1,
                    BarangayName = "Brgy. Ninoy Aquino",
                    Street = "Ninoy Aquino",
                    Municipality = "Angeles City",
                    Province = "Pampanga",
                    Region = "III",
                    ContactNo = "09123441233",
                    BarangayHealthStation = "Barangay Health Station",
                    RuralHealthUnit = "Rural Health Unit"
                });
        }
    }
}
