using AUF.EMR2.Application.Common.Constants;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUF.EMR2.Persistence.Configurations.Entities;

public class PregnancyTrackingHhConfiguration : IEntityTypeConfiguration<PregnancyTrackingHh>
{
    public void Configure(EntityTypeBuilder<PregnancyTrackingHh> builder)
    {
        ConfigurePregnancyTrackingHhTable(builder);
    }

    private static void ConfigurePregnancyTrackingHhTable(EntityTypeBuilder<PregnancyTrackingHh> builder)
    {
        builder.ToTable("PregnancyTrackingHh");
        builder.HasKey(pregHh => pregHh.Id);
        builder.Property(pregHh => pregHh.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PregnancyTrackingHhId.Create(value));

        builder.Property(pregHH => pregHH.MidwifeName).HasMaxLength(TablePropertiesConstants.MaxContactNoLength);
        builder.Property(pregHH => pregHH.BHWName).HasMaxLength(TablePropertiesConstants.MaxContactNoLength);
        builder.Property(pregHH => pregHH.BirthingCenter).HasMaxLength(TablePropertiesConstants.MaxAddressLength);
        builder.Property(pregHH => pregHH.BirthingCenterAddress).HasMaxLength(TablePropertiesConstants.MaxAddressLength);
        builder.Property(pregHH => pregHH.ReferralCenterAddress).HasMaxLength(TablePropertiesConstants.MaxAddressLength);
        builder.Property(pregHH => pregHH.ReferralCenter).HasMaxLength(TablePropertiesConstants.MaxAddressLength);

        builder.Property(pregHh => pregHh.HouseholdId)
            .HasConversion(
                id => id.Value,
                value => HouseholdId.Create(value));

        builder.HasOne<Household>()
            .WithOne()
            .HasForeignKey<PregnancyTrackingHh>("HouseholdId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
