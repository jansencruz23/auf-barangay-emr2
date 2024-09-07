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
    [Migration("20240907091939_AddPregnancyTrackingEntity")]
    partial class AddPregnancyTrackingEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AUF.EMR2.Domain.Models.Household", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barangay")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Category")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("FirstQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FourthQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HouseNoAndStreet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HouseholdNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsHeadPhilhealthMember")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsIP")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsNHTS")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<string>("MotherMaidenName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhilhealthNo")
                        .HasColumnType("longtext");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("SecondQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ThirdQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Households");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Models.HouseholdMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstQtrClassification")
                        .HasColumnType("longtext");

                    b.Property<string>("FourthQtrClassification")
                        .HasColumnType("longtext");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsInSchool")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsNhts")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<string>("MotherMaidenName")
                        .HasColumnType("longtext");

                    b.Property<string>("NameOfFather")
                        .HasColumnType("longtext");

                    b.Property<string>("NameOfMother")
                        .HasColumnType("longtext");

                    b.Property<string>("OtherRelation")
                        .HasColumnType("longtext");

                    b.Property<int>("RelationshipToHouseholdHead")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("longtext");

                    b.Property<string>("SecondQtrClassification")
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ThirdQtrClassification")
                        .HasColumnType("longtext");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.ToTable("HouseholdMembers");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Models.PregnancyTracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("EarlyNewbornDeath")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpectedDateOfDelivery")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FirstAntenatalCheckUp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Gravidity")
                        .HasColumnType("int");

                    b.Property<int>("HouseholdMemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LiveBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("MaternalDeath")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("MoreCheckUp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Parity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PostnatalCheckUp24hrs")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("PostnatalCheckUp7days")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("PregnancyOutcome")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SecondAntenatalCheckUp")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("StillBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ThirdAntenatalCheckUp")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdMemberId");

                    b.ToTable("PregnancyTrackings");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Models.WomanOfReproductiveAge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AcceptModernFpMethod")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CivilStatus")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FPAcceptedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HouseholdMemberId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFPMethod")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsFPModern")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsFecund")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsMFPUnmet")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsPlanChildrenLimiting")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsPlanChildrenNow")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsPlanChildrenSpacing")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPlanningChildren")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModernFPMethod")
                        .HasColumnType("longtext");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<bool?>("ShiftToModern")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdMemberId");

                    b.ToTable("WomenOfReproductiveAge");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Models.HouseholdMember", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Models.Household", "Household")
                        .WithMany("HouseholdMembers")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Models.PregnancyTracking", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Models.HouseholdMember", "HouseholdMember")
                        .WithMany()
                        .HasForeignKey("HouseholdMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HouseholdMember");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Models.WomanOfReproductiveAge", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Models.HouseholdMember", "HouseholdMember")
                        .WithMany()
                        .HasForeignKey("HouseholdMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HouseholdMember");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Models.Household", b =>
                {
                    b.Navigation("HouseholdMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
