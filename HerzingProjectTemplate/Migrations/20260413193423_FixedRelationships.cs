using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerzingProjectTemplate.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProgressPercentage",
                table: "Progresses",
                newName: "WeeklyWorkoutPercentageCompletion");

            migrationBuilder.AddColumn<double>(
                name: "TotalDailyCalories",
                table: "Progresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalWeeklyCalories",
                table: "Progresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalWeeklyCaloriesTaken",
                table: "Progresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalWeeklyFats",
                table: "Progresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalWeeklyProtein",
                table: "Progresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Progresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "WeeklyNutritionPercentageCompletion",
                table: "Progresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDailyCalories",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "TotalWeeklyCalories",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "TotalWeeklyCaloriesTaken",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "TotalWeeklyFats",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "TotalWeeklyProtein",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "WeeklyNutritionPercentageCompletion",
                table: "Progresses");

            migrationBuilder.RenameColumn(
                name: "WeeklyWorkoutPercentageCompletion",
                table: "Progresses",
                newName: "ProgressPercentage");
        }
    }
}
