using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerzingProjectTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToNutrition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Nutritions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Nutritions");
        }
    }
}
