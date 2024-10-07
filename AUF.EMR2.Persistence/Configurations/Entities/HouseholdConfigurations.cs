using AUF.EMR2.Application.Common.Constants;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUF.EMR2.Persistence.Configurations.Entities;

public class HouseholdConfigurations : IEntityTypeConfiguration<Household>
{
    public void Configure(EntityTypeBuilder<Household> builder)
    {
        ConfigureHouseholdsTable(builder);
    }

    private static void ConfigureHouseholdsTable(EntityTypeBuilder<Household> builder)
    {
        builder.ToTable("Households");
        builder.HasKey(household => household.Id);
        builder.Property(household => household.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HouseholdId.Create(value));

        builder.Property(household => household.ContactNo).HasMaxLength(TablePropertiesConstants.MaxContactNoLength);
        builder.Property(household => household.FirstName).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        builder.Property(household => household.LastName).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        builder.Property(household => household.MotherMaidenName).HasMaxLength(TablePropertiesConstants.MaxNameLength);

        builder.OwnsOne(household => household.HouseAddress, addressBuilder =>
        {
            addressBuilder.Property(address => address.HouseNoAndStreet).HasMaxLength(TablePropertiesConstants.MaxAddressLength);
            addressBuilder.Property(address => address.Barangay).HasMaxLength(TablePropertiesConstants.MaxAddressLength);
            addressBuilder.Property(address => address.City).HasMaxLength(TablePropertiesConstants.MaxAddressLength);
            addressBuilder.Property(address => address.Province).HasMaxLength(TablePropertiesConstants.MaxAddressLength);
        });

        builder.OwnsOne(household => household.Philhealth, philhealthBuilder =>
        {
            philhealthBuilder.Property(philhealth => philhealth.PhilhealthNo).HasMaxLength(TablePropertiesConstants.MaxNameLength);
            philhealthBuilder.Property(philhealth => philhealth.Category).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        });
    }
}
