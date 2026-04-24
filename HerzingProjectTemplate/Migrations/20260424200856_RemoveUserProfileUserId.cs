using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerzingProjectTemplate.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserProfileUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_WorkOuts_UserId",
                table: "WorkOuts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOuts_UserProfiles_UserId",
                table: "WorkOuts",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOuts_UserProfiles_UserId",
                table: "WorkOuts");

            migrationBuilder.DropIndex(
                name: "IX_WorkOuts_UserId",
                table: "WorkOuts");

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
    }
}
