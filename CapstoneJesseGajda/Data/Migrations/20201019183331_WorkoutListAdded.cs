using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneJesseGajda.Data.Migrations
{
    public partial class WorkoutListAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutList",
                columns: table => new
                {
                    WorkoutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Exercise_One = table.Column<int>(nullable: false),
                    Exercise_Two = table.Column<int>(nullable: false),
                    Exercise_Three = table.Column<int>(nullable: false),
                    Exercise_Four = table.Column<int>(nullable: false),
                    Exercise_Five = table.Column<int>(nullable: false),
                    Exercise_Six = table.Column<int>(nullable: false),
                    Exercise_Seven = table.Column<int>(nullable: false),
                    Exercise_Eight = table.Column<int>(nullable: false),
                    Exercise_Nine = table.Column<int>(nullable: false),
                    Exercise_Ten = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutList", x => x.WorkoutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutList");
        }
    }
}
