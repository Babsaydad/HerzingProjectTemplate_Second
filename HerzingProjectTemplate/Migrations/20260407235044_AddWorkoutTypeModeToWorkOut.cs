using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerzingProjectTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutTypeModeToWorkOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkoutTypeMode",
                table: "WorkOuts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutTypeMode",
                table: "WorkOuts");
        }
    }
}
