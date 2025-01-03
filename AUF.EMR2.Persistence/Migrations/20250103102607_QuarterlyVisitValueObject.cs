using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class QuarterlyVisitValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("ce2cc1cf-835b-4ea9-a8b8-210d73e82128"));

            migrationBuilder.DropColumn(
                name: "FirstQtrVisit",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "FourthQtrVisit",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "SecondQtrVisit",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "ThirdQtrVisit",
                table: "Households");

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("dad41aa9-8733-4276-ab4f-1a8cfe469b1f"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2025, 1, 3, 18, 26, 7, 383, DateTimeKind.Local).AddTicks(6881), null, new DateTime(2025, 1, 3, 18, 26, 7, 383, DateTimeKind.Local).AddTicks(6892), null, null, "Rural Health Unit", true, new Guid("6530714b-e7db-421b-ad68-12fb70d3607e") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("dad41aa9-8733-4276-ab4f-1a8cfe469b1f"));

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstQtrVisit",
                table: "Households",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FourthQtrVisit",
                table: "Households",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecondQtrVisit",
                table: "Households",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThirdQtrVisit",
                table: "Households",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("ce2cc1cf-835b-4ea9-a8b8-210d73e82128"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2025, 1, 3, 17, 51, 9, 733, DateTimeKind.Local).AddTicks(4952), null, new DateTime(2025, 1, 3, 17, 51, 9, 733, DateTimeKind.Local).AddTicks(4963), null, null, "Rural Health Unit", true, new Guid("2f3ed443-f9e4-49fd-a2e7-91a685f1709c") });
        }
    }
}
