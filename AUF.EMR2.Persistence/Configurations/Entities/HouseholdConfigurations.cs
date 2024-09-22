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

        builder.Property(household => household.ContactNo).HasMaxLength(HouseholdConstants.MaxContactNoLength);
        builder.Property(household => household.FirstName).HasMaxLength(HouseholdConstants.MaxNameLength);
        builder.Property(household => household.LastName).HasMaxLength(HouseholdConstants.MaxNameLength);
        builder.Property(household => household.MotherMaidenName).HasMaxLength(HouseholdConstants.MaxNameLength);

        builder.OwnsOne(household => household.HouseAddress, addressBuilder =>
        {
            addressBuilder.Property(address => address.HouseNoAndStreet).HasMaxLength(HouseholdConstants.MaxAddressLength);
            addressBuilder.Property(address => address.Barangay).HasMaxLength(HouseholdConstants.MaxAddressLength);
            addressBuilder.Property(address => address.City).HasMaxLength(HouseholdConstants.MaxAddressLength);
            addressBuilder.Property(address => address.Province).HasMaxLength(HouseholdConstants.MaxAddressLength);
        });

        builder.OwnsOne(household => household.Philhealth);
    }
}
