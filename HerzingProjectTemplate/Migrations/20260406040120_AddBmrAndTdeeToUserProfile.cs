using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerzingProjectTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AddBmrAndTdeeToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BMR",
                table: "UserProfiles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TDEE",
                table: "UserProfiles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BMR",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "TDEE",
                table: "UserProfiles");
        }
    }
}
