using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR2.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class pregnancytrackinghh2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PregnancyTrackingHh_HouseholdId",
                table: "PregnancyTrackingHh",
                column: "HouseholdId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PregnancyTrackingHh_Households_HouseholdId",
                table: "PregnancyTrackingHh",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PregnancyTrackingHh_Households_HouseholdId",
                table: "PregnancyTrackingHh");

            migrationBuilder.DropIndex(
                name: "IX_PregnancyTrackingHh_HouseholdId",
                table: "PregnancyTrackingHh");
        }
    }
}
