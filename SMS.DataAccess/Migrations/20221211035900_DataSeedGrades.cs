using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.DataAccess.Migrations
{
    public partial class DataSeedGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Min_mark = table.Column<int>(type: "int", nullable: false),
                    Max_mark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Max_mark", "Min_mark", "Name" },
                values: new object[,]
                {
                    { 1, 9, 0, "D" },
                    { 2, 19, 10, "C-" },
                    { 3, 29, 20, "C" },
                    { 4, 39, 30, "C+" },
                    { 5, 49, 40, "B-" },
                    { 6, 59, 50, "B" },
                    { 7, 69, 60, "B+" },
                    { 8, 79, 70, "A-" },
                    { 9, 89, 80, "A" },
                    { 10, 100, 90, "A+" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Credits", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Science" },
                    { 2, 3, "English" },
                    { 3, 3, "Maths" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
