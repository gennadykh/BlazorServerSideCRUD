using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorServerSideCRUD.Migrations.SurveyDb
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 200, nullable: false),
                    QuestionType = table.Column<string>(maxLength: 200, nullable: false),
                    Options = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyUser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: true),
                    UserName = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: false),
                    Role = table.Column<int>(nullable: false),
                    Role1ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SurveyUser_Role_Role1ID",
                        column: x => x.Role1ID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ExpiresOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    Publish = table.Column<bool>(nullable: false)
                    //? UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Survey_SurveyUser_UserID",
                        column: x => x.ID,
                        principalTable: "SurveyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Survey_Questions",
                columns: table => new
                {
                    SurveyID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey_Questions", x => new { x.SurveyID, x.QuestionID });
                    table.ForeignKey(
                        name: "FK_Survey_Questions_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_Questions_Survey_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResponse",
                columns: table => new
                {
                    SurveyID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    Response = table.Column<string>(maxLength: 200, nullable: true),
                    FilledBy = table.Column<int>(nullable: false)
                    //? UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponse", x => new { x.SurveyID, x.QuestionID });
                    table.ForeignKey(
                        name: "FK_SurveyResponse_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyResponse_Survey_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyResponse_SurveyUser_UserID",
                        column: x => x.ID,
                        principalTable: "SurveyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "ID", "Options", "QuestionType", "Text" },
                values: new object[,]
                {
                    { 1, "TX:15521 Import CAESAR,TX:4877 Support Jacketed Piping,TX:9146-Main Thickness Table", "MultiLineTextBox", "CADWorx Plant: Rank the following items with the highest priority for you and your market first." },
                    { 2, "TX:20983-Support Circular,TX:5002-Steel BOM TOTAL", "MultiLineTextBox", "CADWorx Structure: Rank the following items with the highest priority for you and your market first." }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "DBO" },
                    { 2, "SA" },
                    { 3, "PUBLIC" }
                });

            migrationBuilder.InsertData(
                table: "Survey",
                columns: new[] { "ID", "CreatedBy", "CreatedOn", "Description", "ExpiresOn", "Publish", "Title" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2020, 10, 1, 9, 47, 35, 996, DateTimeKind.Local).AddTicks(6618), "my description", new DateTime(2021, 10, 1, 9, 47, 36, 2, DateTimeKind.Local).AddTicks(9513), true, "Title 1" },
                    { 2, 2, new DateTime(2020, 10, 1, 9, 47, 36, 3, DateTimeKind.Local).AddTicks(1222), "my description", new DateTime(2021, 10, 1, 9, 47, 36, 3, DateTimeKind.Local).AddTicks(1241), true, "Feed back from" }
                });

            migrationBuilder.InsertData(
                table: "SurveyUser",
                columns: new[] { "ID", "FirstName", "LastName", "Password", "Role", "Role1ID", "UserName" },
                values: new object[,]
                {
                    { 2, "Gennady", "Khokhorin", "12345", 1, null, "GOK" },
                    { 3, "Gopi", "Kandru", "12345", 4, null, "Gk" },
                    { 4, "Garrett", "Walker", "12345", 4, null, "Gw" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Survey_UserID",
                table: "Survey",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_Questions_QuestionID",
                table: "Survey_Questions",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponse_QuestionID",
                table: "SurveyResponse",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponse_UserID",
                table: "SurveyResponse",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyUser_Role1ID",
                table: "SurveyUser",
                column: "Role1ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Survey_Questions");

            migrationBuilder.DropTable(
                name: "SurveyResponse");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "SurveyUser");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
