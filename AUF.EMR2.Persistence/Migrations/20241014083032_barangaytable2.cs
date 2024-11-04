using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class barangaytable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BHWName",
                table: "PregnancyTrackingHh",
                newName: "BhwName");

            migrationBuilder.CreateTable(
                name: "Barangays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BarangayName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logo = table.Column<byte[]>(type: "longblob", nullable: true),
                    Street = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Municipality = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Province = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNo = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BarangayHealthStation = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RuralHealthUnit = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedById = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barangays", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("198743c4-da4d-44cd-93f9-70e6b078e728"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2024, 10, 14, 16, 30, 31, 743, DateTimeKind.Local).AddTicks(575), null, new DateTime(2024, 10, 14, 16, 30, 31, 743, DateTimeKind.Local).AddTicks(590), null, null, "Rural Health Unit", true, new Guid("105bf64a-7b6c-4970-b839-663713e6ff01") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barangays");

            migrationBuilder.RenameColumn(
                name: "BhwName",
                table: "PregnancyTrackingHh",
                newName: "BHWName");
        }
    }
}
