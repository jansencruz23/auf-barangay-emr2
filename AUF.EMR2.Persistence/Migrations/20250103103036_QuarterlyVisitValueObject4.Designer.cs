﻿// <auto-generated />
using System;
using AUF.EMR2.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    [DbContext(typeof(EmrDbContext))]
    [Migration("20250103103036_QuarterlyVisitValueObject4")]
    partial class QuarterlyVisitValueObject4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AUF.EMR2.Domain.Aggregates.BarangayAggregate.Barangay", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("BarangayHealthStation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BarangayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("longblob");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<string>("RuralHealthUnit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Barangays", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f4c3074e-1aa0-49ab-933c-8ecfdfb35d78"),
                            BarangayHealthStation = "Barangay Health Station",
                            BarangayName = "Brgy. Ninoy Aquino",
                            ContactNo = "09XXXXXXXXX",
                            DateCreated = new DateTime(2025, 1, 3, 18, 30, 36, 27, DateTimeKind.Local).AddTicks(612),
                            LastModified = new DateTime(2025, 1, 3, 18, 30, 36, 27, DateTimeKind.Local).AddTicks(628),
                            RuralHealthUnit = "Rural Health Unit",
                            Status = true,
                            Version = new Guid("0b648ec6-928e-4987-b407-713db946e2f5")
                        });
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Household", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("HouseholdNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsIp")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsNhts")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<string>("MotherMaidenName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Households", (string)null);
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.HouseholdMember", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("HouseholdId")
                        .HasColumnType("char(36)");

                    b.Property<bool?>("IsInSchool")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsNhts")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<string>("MotherMaidenName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NameOfFather")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NameOfMother")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("OtherRelation")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("RelationshipToHouseholdHead")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("longtext");

                    b.Property<int>("Sex")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId")
                        .IsUnique();

                    b.ToTable("HouseholdMembers", (string)null);
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.PregnancyTrackingHh", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("BhwName")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("BirthingCenter")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("BirthingCenterAddress")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("HouseholdId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MidwifeName")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<string>("ReferralCenter")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ReferralCenterAddress")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId")
                        .IsUnique();

                    b.ToTable("PregnancyTrackingHh", (string)null);
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Aggregates.BarangayAggregate.Barangay", b =>
                {
                    b.OwnsOne("AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects.BarangayAddress", "BarangayAddress", b1 =>
                        {
                            b1.Property<Guid>("BarangayId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Municipality")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Municipality");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Province");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Region");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Street");

                            b1.HasKey("BarangayId");

                            b1.ToTable("Barangays");

                            b1.WithOwner()
                                .HasForeignKey("BarangayId");
                        });

                    b.Navigation("BarangayAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Household", b =>
                {
                    b.OwnsOne("AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects.HouseAddress", "HouseAddress", b1 =>
                        {
                            b1.Property<Guid>("HouseholdId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Barangay")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)");

                            b1.Property<string>("HouseNoAndStreet")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)");

                            b1.HasKey("HouseholdId");

                            b1.ToTable("Households");

                            b1.WithOwner()
                                .HasForeignKey("HouseholdId");
                        });

                    b.OwnsOne("AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects.Philhealth", "Philhealth", b1 =>
                        {
                            b1.Property<Guid>("HouseholdId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Category")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("PhilhealthNo")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)");

                            b1.HasKey("HouseholdId");

                            b1.ToTable("Households");

                            b1.WithOwner()
                                .HasForeignKey("HouseholdId");
                        });

                    b.OwnsOne("AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects.QuarterlyVisit", "QuarterlyVisit", b1 =>
                        {
                            b1.Property<Guid>("HouseholdId")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime?>("FirstQtrVisit")
                                .HasColumnType("DateTime");

                            b1.Property<DateTime?>("FourthQtrVisit")
                                .HasColumnType("DateTime");

                            b1.Property<DateTime?>("SecondQtrVisit")
                                .HasColumnType("DateTime");

                            b1.Property<DateTime?>("ThirdQtrVisit")
                                .HasColumnType("DateTime");

                            b1.HasKey("HouseholdId");

                            b1.ToTable("Households");

                            b1.WithOwner()
                                .HasForeignKey("HouseholdId");
                        });

                    b.Navigation("HouseAddress")
                        .IsRequired();

                    b.Navigation("Philhealth")
                        .IsRequired();

                    b.Navigation("QuarterlyVisit");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.HouseholdMember", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Household", null)
                        .WithOne()
                        .HasForeignKey("AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.HouseholdMember", "HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects.QuarterlyClassification", "QuarterlyClassification", b1 =>
                        {
                            b1.Property<Guid>("HouseholdMemberId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("FirstQtrClassification")
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("FourthQtrClassification")
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("SecondQtrClassification")
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("ThirdQtrClassification")
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.HasKey("HouseholdMemberId");

                            b1.ToTable("HouseholdMembers");

                            b1.WithOwner()
                                .HasForeignKey("HouseholdMemberId");
                        });

                    b.Navigation("QuarterlyClassification");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.PregnancyTrackingHh", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Household", null)
                        .WithOne()
                        .HasForeignKey("AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.PregnancyTrackingHh", "HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
