using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NC1TestTask.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Floor = table.Column<short>(type: "smallint", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    PLId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.PLId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nVarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nVarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_ProgrammingLanguages_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "PLId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Discriminator", "Floor", "Department" },
                values: new object[,]
                {
                    { 1, "Department", (short)-1, "Engenering" },
                    { 2, "Department", (short)0, "Human Resources" },
                    { 3, "Department", (short)1, "Design Head" }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "PLId", "Discriminator", "Language" },
                values: new object[,]
                {
                    { 1, "ProgrammingLanguage", "C#" },
                    { 2, "ProgrammingLanguage", "Java" },
                    { 3, "ProgrammingLanguage", "Pyton" },
                    { 4, "ProgrammingLanguage", "Scala" },
                    { 5, "ProgrammingLanguage", "Java Script" },
                    { 6, "ProgrammingLanguage", "C" },
                    { 7, "ProgrammingLanguage", "C++" },
                    { 8, "ProgrammingLanguage", "PHP" },
                    { 9, "ProgrammingLanguage", "Visual Basic" },
                    { 10, "ProgrammingLanguage", "Swift" },
                    { 11, "ProgrammingLanguage", "NodeJS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
