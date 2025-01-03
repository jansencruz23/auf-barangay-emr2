﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class QuarterlyVisitValueObject2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("dad41aa9-8733-4276-ab4f-1a8cfe469b1f"));

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("e18c9dc6-871e-4a34-aaee-da512b576c43"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2025, 1, 3, 18, 27, 27, 512, DateTimeKind.Local).AddTicks(3777), null, new DateTime(2025, 1, 3, 18, 27, 27, 512, DateTimeKind.Local).AddTicks(3787), null, null, "Rural Health Unit", true, new Guid("723c93ab-2a52-445b-8148-f5f20c83f614") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("e18c9dc6-871e-4a34-aaee-da512b576c43"));

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("dad41aa9-8733-4276-ab4f-1a8cfe469b1f"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2025, 1, 3, 18, 26, 7, 383, DateTimeKind.Local).AddTicks(6881), null, new DateTime(2025, 1, 3, 18, 26, 7, 383, DateTimeKind.Local).AddTicks(6892), null, null, "Rural Health Unit", true, new Guid("6530714b-e7db-421b-ad68-12fb70d3607e") });
        }
    }
}
