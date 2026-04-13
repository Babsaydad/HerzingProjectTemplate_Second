using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerzingProjectTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AddNutritionToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileUserId",
                table: "Nutritions",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutritions_UserProfiles_UserProfileUserId",
                table: "Nutritions");

            migrationBuilder.DropIndex(
                name: "IX_Nutritions_UserProfileUserId",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "UserProfileUserId",
                table: "Nutritions");
        }
    }
}
