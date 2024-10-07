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
    [Migration("20241007020706_pregnancytrackinghh")]
    partial class pregnancytrackinghh
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

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

                    b.Property<DateTime?>("FirstQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FourthQtrVisit")
                        .HasColumnType("datetime(6)");

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

                    b.Property<DateTime?>("SecondQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ThirdQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Version")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Households", (string)null);
                });

            modelBuilder.Entity("AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate.PregnancyTrackingHh", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("BHWName")
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

                    b.ToTable("PregnancyTrackingHh", (string)null);
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

                    b.Navigation("HouseAddress")
                        .IsRequired();

                    b.Navigation("Philhealth")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
