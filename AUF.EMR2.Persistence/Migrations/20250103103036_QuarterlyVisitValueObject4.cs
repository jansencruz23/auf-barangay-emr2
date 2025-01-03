using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class QuarterlyVisitValueObject4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("ae4166e9-8bd4-434c-aa27-00ee45c6cb00"));

            migrationBuilder.AddColumn<DateTime>(
                name: "QuarterlyVisit_FourthQtrVisit",
                table: "Households",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "QuarterlyVisit_SecondQtrVisit",
                table: "Households",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "QuarterlyVisit_ThirdQtrVisit",
                table: "Households",
                type: "DateTime",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("f4c3074e-1aa0-49ab-933c-8ecfdfb35d78"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2025, 1, 3, 18, 30, 36, 27, DateTimeKind.Local).AddTicks(612), null, new DateTime(2025, 1, 3, 18, 30, 36, 27, DateTimeKind.Local).AddTicks(628), null, null, "Rural Health Unit", true, new Guid("0b648ec6-928e-4987-b407-713db946e2f5") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("f4c3074e-1aa0-49ab-933c-8ecfdfb35d78"));

            migrationBuilder.DropColumn(
                name: "QuarterlyVisit_FourthQtrVisit",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "QuarterlyVisit_SecondQtrVisit",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "QuarterlyVisit_ThirdQtrVisit",
                table: "Households");

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("ae4166e9-8bd4-434c-aa27-00ee45c6cb00"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2025, 1, 3, 18, 29, 52, 23, DateTimeKind.Local).AddTicks(4229), null, new DateTime(2025, 1, 3, 18, 29, 52, 23, DateTimeKind.Local).AddTicks(4242), null, null, "Rural Health Unit", true, new Guid("ec3d1927-cba5-4858-8056-069d9af0d601") });
        }
    }
}
