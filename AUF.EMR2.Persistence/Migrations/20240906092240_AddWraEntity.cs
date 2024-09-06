using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddWraEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WomenOfReproductiveAge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HouseholdMemberId = table.Column<int>(type: "int", nullable: false),
                    CivilStatus = table.Column<int>(type: "int", nullable: false),
                    IsPlanningChildren = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsPlanChildrenNow = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPlanChildrenSpacing = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPlanChildrenLimiting = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsFecund = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFPMethod = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFPModern = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ShiftToModern = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMFPUnmet = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AcceptModernFpMethod = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModernFPMethod = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FPAcceptedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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
                    table.PrimaryKey("PK_WomenOfReproductiveAge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WomenOfReproductiveAge_HouseholdMembers_HouseholdMemberId",
                        column: x => x.HouseholdMemberId,
                        principalTable: "HouseholdMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WomenOfReproductiveAge_HouseholdMemberId",
                table: "WomenOfReproductiveAge",
                column: "HouseholdMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WomenOfReproductiveAge");
        }
    }
}
