using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerzingProjectTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AddMakeUserIdTheForeignKeyInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutritions_UserProfiles_UserProfileUserId",
                table: "Nutritions");

            migrationBuilder.DropIndex(
                name: "IX_Nutritions_UserProfileUserId",
                table: "Nutritions");

            migrationBuilder.RenameColumn(
                name: "UserProfileUserId",
                table: "Nutritions",
                newName: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritions_UserId2",
                table: "Nutritions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutritions_UserProfiles_UserId",
                table: "Nutritions",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutritions_UserProfiles_UserId",
                table: "Nutritions");

            migrationBuilder.DropIndex(
                name: "IX_Nutritions_UserId",
                table: "Nutritions");

            migrationBuilder.RenameColumn(
                name: "UserId2",
                table: "Nutritions",
                newName: "UserProfileUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritions_UserProfileUserId",
                table: "Nutritions",
                column: "UserProfileUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutritions_UserProfiles_UserProfileUserId",
                table: "Nutritions",
                column: "UserProfileUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }
    }
}
