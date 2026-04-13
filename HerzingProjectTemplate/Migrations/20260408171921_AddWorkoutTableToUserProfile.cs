using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerzingProjectTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutTableToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileUserId",
                table: "WorkOuts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOuts_UserProfileUserId",
                table: "WorkOuts",
                column: "UserProfileUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOuts_UserProfiles_UserProfileUserId",
                table: "WorkOuts",
                column: "UserProfileUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOuts_UserProfiles_UserProfileUserId",
                table: "WorkOuts");

            migrationBuilder.DropIndex(
                name: "IX_WorkOuts_UserProfileUserId",
                table: "WorkOuts");

            migrationBuilder.DropColumn(
                name: "UserProfileUserId",
                table: "WorkOuts");
        }
    }
}
