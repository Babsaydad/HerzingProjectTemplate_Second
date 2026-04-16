using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerzingProjectTemplate.Migrations
{
    /// <inheritdoc />
    public partial class CheckedForMismatchBetweenDBAndModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "WorkOuts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "Nutritions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOuts_ProgressId",
                table: "WorkOuts",
                column: "ProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritions_ProgressId",
                table: "Nutritions",
                column: "ProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutritions_Progresses_ProgressId",
                table: "Nutritions",
                column: "ProgressId",
                principalTable: "Progresses",
                principalColumn: "ProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOuts_Progresses_ProgressId",
                table: "WorkOuts",
                column: "ProgressId",
                principalTable: "Progresses",
                principalColumn: "ProgressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutritions_Progresses_ProgressId",
                table: "Nutritions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOuts_Progresses_ProgressId",
                table: "WorkOuts");

            migrationBuilder.DropIndex(
                name: "IX_WorkOuts_ProgressId",
                table: "WorkOuts");

            migrationBuilder.DropIndex(
                name: "IX_Nutritions_ProgressId",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "WorkOuts");

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "Nutritions");
        }
    }
}
