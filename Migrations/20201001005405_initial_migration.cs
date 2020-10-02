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
                    { "25c05917-cb3b-47ab-8af0-54489cf3f52a", "Jane", "Smith", "Medicine" },
                    { "4f05f61f-15ea-4ef9-aa17-b61878b9a554", "John", "Fisher", "Engineering" },
                    { "f1c2b660-302b-46dc-a261-a1d23404aaa1", "Pamela", "Baker", "Food Science" },
                    { "a24cdad6-617b-477c-8d97-3fc218c76718", "Peter", "Taylor", "Mining" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
