using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHouseholdMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("198743c4-da4d-44cd-93f9-70e6b078e728"));

            migrationBuilder.CreateTable(
                name: "HouseholdMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotherMaidenName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RelationshipToHouseholdHead = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    OtherRelation = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sex = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    QuarterlyClassification_FirstQtrClassification = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuarterlyClassification_SecondQtrClassification = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuarterlyClassification_ThirdQtrClassification = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuarterlyClassification_FourthQtrClassification = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOfMother = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOfFather = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNhts = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsInSchool = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    HouseholdId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                    table.PrimaryKey("PK_HouseholdMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseholdMembers_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("ce2cc1cf-835b-4ea9-a8b8-210d73e82128"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2025, 1, 3, 17, 51, 9, 733, DateTimeKind.Local).AddTicks(4952), null, new DateTime(2025, 1, 3, 17, 51, 9, 733, DateTimeKind.Local).AddTicks(4963), null, null, "Rural Health Unit", true, new Guid("2f3ed443-f9e4-49fd-a2e7-91a685f1709c") });

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMembers_HouseholdId",
                table: "HouseholdMembers",
                column: "HouseholdId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseholdMembers");

            migrationBuilder.DeleteData(
                table: "Barangays",
                keyColumn: "Id",
                keyValue: new Guid("ce2cc1cf-835b-4ea9-a8b8-210d73e82128"));

            migrationBuilder.InsertData(
                table: "Barangays",
                columns: new[] { "Id", "BarangayHealthStation", "BarangayName", "ContactNo", "CreatedBy", "DateCreated", "Description", "LastModified", "Logo", "ModifiedById", "RuralHealthUnit", "Status", "Version" },
                values: new object[] { new Guid("198743c4-da4d-44cd-93f9-70e6b078e728"), "Barangay Health Station", "Brgy. Ninoy Aquino", "09XXXXXXXXX", null, new DateTime(2024, 10, 14, 16, 30, 31, 743, DateTimeKind.Local).AddTicks(575), null, new DateTime(2024, 10, 14, 16, 30, 31, 743, DateTimeKind.Local).AddTicks(590), null, null, "Rural Health Unit", true, new Guid("105bf64a-7b6c-4970-b839-663713e6ff01") });
        }
    }
}
