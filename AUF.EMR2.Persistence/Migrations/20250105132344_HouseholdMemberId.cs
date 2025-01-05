using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class HouseholdMemberId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("f4c3074e-1aa0-49ab-933c-8ecfdfb35d78"));

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("5c1b10fa-7a0b-4e6b-a9ef-e148c8acb50f"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2025, 1, 5, 21, 23, 42, 359, DateTimeKind.Local).AddTicks(1565), null, new DateTime(2025, 1, 5, 21, 23, 42, 359, DateTimeKind.Local).AddTicks(1576), null, null, "Rural Health Unit", true, new Guid("2d7b85c3-3582-4fad-8fcf-69d489ed46f4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("5c1b10fa-7a0b-4e6b-a9ef-e148c8acb50f"));

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("f4c3074e-1aa0-49ab-933c-8ecfdfb35d78"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2025, 1, 3, 18, 30, 36, 27, DateTimeKind.Local).AddTicks(612), null, new DateTime(2025, 1, 3, 18, 30, 36, 27, DateTimeKind.Local).AddTicks(628), null, null, "Rural Health Unit", true, new Guid("0b648ec6-928e-4987-b407-713db946e2f5") });
        }
    }
}
