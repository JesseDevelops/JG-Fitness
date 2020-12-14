using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneJesseGajda.Data.Migrations
{
    public partial class AddedExerciseName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Exercise_Name",
                table: "WorkoutList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exercise_Name",
                table: "WorkoutList");
        }
    }
}
