using AUF.EMR2.Application.Common.Constants;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUF.EMR2.Persistence.Configurations.Entities;

public sealed class HouseholdMemberConfiguration : IEntityTypeConfiguration<HouseholdMember>
{
    public void Configure(EntityTypeBuilder<HouseholdMember> builder)
    {
        CongifureHouseholdMembersTable(builder);
    }

    private static void CongifureHouseholdMembersTable(EntityTypeBuilder<HouseholdMember> builder)
    {
        builder.ToTable("HouseholdMembers");
        builder.HasKey(member => member.Id);
        builder.Property(member => member.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HouseholdMemberId.Create(value));

        builder.Property(member => member.LastName).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        builder.Property(member => member.FirstName).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        builder.Property(member => member.MotherMaidenName).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        builder.Property(member => member.RelationshipToHouseholdHead).HasMaxLength(TablePropertiesConstants.MaxEnumLength);
        builder.Property(member => member.OtherRelation).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        builder.Property(member => member.Sex).HasMaxLength(TablePropertiesConstants.MaxEnumLength);
        builder.Property(member => member.NameOfFather).HasMaxLength(TablePropertiesConstants.MaxNameLength);
        builder.Property(member => member.NameOfMother).HasMaxLength(TablePropertiesConstants.MaxNameLength);

        builder.OwnsOne(household => household.QuarterlyClassification, qtrBuilder =>
        {
            qtrBuilder.Property(qtr => qtr.FirstQtrClassification).HasMaxLength(TablePropertiesConstants.MaxCategoryLength);
            qtrBuilder.Property(qtr => qtr.SecondQtrClassification).HasMaxLength(TablePropertiesConstants.MaxCategoryLength);
            qtrBuilder.Property(qtr => qtr.ThirdQtrClassification).HasMaxLength(TablePropertiesConstants.MaxCategoryLength);
            qtrBuilder.Property(qtr => qtr.FourthQtrClassification).HasMaxLength(TablePropertiesConstants.MaxCategoryLength);
        });

        builder.Property(member => member.HouseholdId)
            .HasConversion(
                id => id.Value,
                value => HouseholdId.Create(value));

        builder.HasOne<Household>()
            .WithMany()
            .HasForeignKey(member => member.HouseholdId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
