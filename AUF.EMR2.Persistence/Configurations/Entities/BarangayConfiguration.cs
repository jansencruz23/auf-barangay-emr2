using AUF.EMR2.Application.Common.Constants;
using AUF.EMR2.Domain.Aggregates.BarangayAggregate;
using AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUF.EMR2.Persistence.Configurations.Entities;

public class BarangayConfiguration : IEntityTypeConfiguration<Barangay>
{
    public void Configure(EntityTypeBuilder<Barangay> builder)
    {
        ConfigureBarangaysTable(builder);
    }

    private static void ConfigureBarangaysTable(EntityTypeBuilder<Barangay> builder)
    {
        builder.ToTable("Barangays");
        builder.HasKey(brgy => brgy.Id);
        builder.Property(brgy => brgy.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BarangayId.Create(value));

        builder.Property(brgy => brgy.BarangayName).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        builder.Property(brgy => brgy.ContactNo).HasMaxLength(TablePropertiesConstants.MaxContactNoLength);
        builder.Property(brgy => brgy.BarangayHealthStation).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        builder.Property(brgy => brgy.RuralHealthUnit).HasMaxLength(TablePropertiesConstants.MaxNameLength);

        builder.OwnsOne(brgy => brgy.BarangayAddress, addressBuilder =>
        {
            addressBuilder.Property(address => address.Street)
                .HasMaxLength(TablePropertiesConstants.MaxAddressLength)
                .HasColumnName("Street");

            addressBuilder.Property(address => address.Municipality)
                .HasMaxLength(TablePropertiesConstants.MaxAddressLength)
                .HasColumnName("Municipality");

            addressBuilder.Property(address => address.Province)
                .HasMaxLength(TablePropertiesConstants.MaxAddressLength)
                .HasColumnName("Province");

            addressBuilder.Property(address => address.Region)
                .HasMaxLength(TablePropertiesConstants.MaxAddressLength)
                .HasColumnName("Region");
        });

        var barangay = CreateBarangay();
        builder.HasData(barangay);
    }

    private static object CreateBarangay()
    {
        return new
        {
            Id = BarangayId.Create(),
            BarangayName = "Brgy. Ninoy Aquino",
            ContactNo = "09XXXXXXXXX",
            BarangayHealthStation = "Barangay Health Station",
            RuralHealthUnit = "Rural Health Unit",
            Street = "Ninoy Aquino",
            Municipality = "Angeles City",
            Province = "Pampanga",
            Region = "III",
            DateCreated = DateTime.Now,
            LastModified = DateTime.Now,
            Status = true,
            Version = Guid.NewGuid()
        };
    }
}
