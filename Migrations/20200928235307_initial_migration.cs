using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorServerSideCRUD.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    School = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "School" },
                values: new object[,]
                {
                    { "4fa9fcf2-777d-4692-993d-5d2ff6ccb4d6", "Jane", "Smith", "Medicine" },
                    { "85c0d3a2-0718-4940-8e84-f85cdc29be8f", "John", "Fisher", "Engineering" },
                    { "3c397645-75d8-488a-ac6b-3b06bc1ee3e9", "Pamela", "Baker", "Food Science" },
                    { "52bbcd5d-105c-4926-bdf0-f929d54ee2e5", "Peter", "Taylor", "Mining" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
