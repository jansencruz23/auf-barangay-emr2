﻿// <auto-generated />
using System;
using AUF.EMR2.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    [DbContext(typeof(EmrDbContext))]
    partial class EmrDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.AdministeredVaccine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("VaccinationAppointmentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VaccineId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("VaccinationAppointmentId");

                    b.HasIndex("VaccineId");

                    b.ToTable("AdministeredVaccines");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.Barangay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BarangayHealthStation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BarangayName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("longtext");

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

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RuralHealthUnit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Barangays");

                    b.HasData(
                        new
                        {
                            Id = new Guid("484d39ef-1a24-4b4a-941f-05700f27484e"),
                            BarangayHealthStation = "Barangay Health Station",
                            BarangayName = "Brgy. Ninoy Aquino",
                            ContactNo = "09123441233",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Municipality = "Angeles City",
                            Province = "Pampanga",
                            Region = "III",
                            RuralHealthUnit = "Rural Health Unit",
                            Status = true,
                            Street = "Ninoy Aquino",
                            Version = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.Household", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

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

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.HouseholdMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

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

                    b.Property<Guid>("HouseholdId1")
                        .HasColumnType("char(36)");

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

                    b.HasIndex("HouseholdId1");

                    b.ToTable("HouseholdMembers");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.PregnancyTracking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

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

                    b.Property<Guid>("HouseholdMemberId1")
                        .HasColumnType("char(36)");

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

                    b.HasIndex("HouseholdMemberId1");

                    b.ToTable("PregnancyTrackings");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.PregnancyTrackingHh", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BHWName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("BarangayId")
                        .HasColumnType("char(36)");

                    b.Property<string>("BirthingCenter")
                        .HasColumnType("longtext");

                    b.Property<string>("BirthingCenterAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("HouseholdId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MidwifeName")
                        .HasColumnType("longtext");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<string>("ReferralCenter")
                        .HasColumnType("longtext");

                    b.Property<string>("ReferralCenterAddress")
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BarangayId");

                    b.HasIndex("HouseholdId")
                        .IsUnique();

                    b.ToTable("PregnancyTrackingHhs");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.VaccinationAppointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<double?>("Temperature")
                        .HasColumnType("double");

                    b.Property<DateTime>("VaccinationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("VaccinationRecordId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("VaccinationRecordId");

                    b.ToTable("VaccinationAppointments");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.VaccinationRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Attended")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FatherAge")
                        .HasColumnType("int");

                    b.Property<DateTime>("FatherBirthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<int>("MotherAge")
                        .HasColumnType("int");

                    b.Property<DateTime>("MotherBirthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<Guid>("PatientId1")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TypeOfDelivery")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PatientId1");

                    b.ToTable("VaccinationRecords");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.Vaccine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.WomanOfReproductiveAge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

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

                    b.Property<Guid>("HouseholdMemberId1")
                        .HasColumnType("char(36)");

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

                    b.HasIndex("HouseholdMemberId1");

                    b.ToTable("WomenOfReproductiveAge");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.AdministeredVaccine", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Entities.VaccinationAppointment", "VaccinationAppointment")
                        .WithMany("AdministeredVaccines")
                        .HasForeignKey("VaccinationAppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AUF.EMR2.Domain.Entities.Vaccine", "Vaccine")
                        .WithMany("AdministeredVaccines")
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VaccinationAppointment");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.HouseholdMember", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Entities.Household", "Household")
                        .WithMany("HouseholdMembers")
                        .HasForeignKey("HouseholdId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.PregnancyTracking", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Entities.HouseholdMember", "HouseholdMember")
                        .WithMany()
                        .HasForeignKey("HouseholdMemberId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HouseholdMember");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.PregnancyTrackingHh", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Entities.Barangay", "Barangay")
                        .WithMany()
                        .HasForeignKey("BarangayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AUF.EMR2.Domain.Entities.Household", "Household")
                        .WithOne()
                        .HasForeignKey("AUF.EMR2.Domain.Entities.PregnancyTrackingHh", "HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barangay");

                    b.Navigation("Household");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.VaccinationAppointment", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Entities.VaccinationRecord", "VaccinationRecord")
                        .WithMany("VaccinationAppointments")
                        .HasForeignKey("VaccinationRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VaccinationRecord");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.VaccinationRecord", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Entities.HouseholdMember", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.WomanOfReproductiveAge", b =>
                {
                    b.HasOne("AUF.EMR2.Domain.Entities.HouseholdMember", "HouseholdMember")
                        .WithMany()
                        .HasForeignKey("HouseholdMemberId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HouseholdMember");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.Household", b =>
                {
                    b.Navigation("HouseholdMembers");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.VaccinationAppointment", b =>
                {
                    b.Navigation("AdministeredVaccines");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.VaccinationRecord", b =>
                {
                    b.Navigation("VaccinationAppointments");
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Entities.Vaccine", b =>
                {
                    b.Navigation("AdministeredVaccines");
                });
#pragma warning restore 612, 618
        }
    }
}
