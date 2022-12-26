using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NC1TestTask.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Floor = table.Column<short>(type: "smallint", nullable: true)
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
                    Language = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.PLId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nVarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nVarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    CurrentDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_CurrentDepartmentId",
                        column: x => x.CurrentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProgLanguage",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    LenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProgLanguage", x => new { x.EmpId, x.LenId });
                    table.ForeignKey(
                        name: "FK_EmployeeProgLanguage_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProgLanguage_ProgrammingLanguages_LenId",
                        column: x => x.LenId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "PLId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Floor", "Department" },
                values: new object[,]
                {
                    { 1, (short)-1, "Engenering" },
                    { 2, (short)0, "Human Resources" },
                    { 3, (short)1, "Design Head" }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "PLId", "Language" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Java" },
                    { 3, "Pyton" },
                    { 4, "Scala" },
                    { 5, "Java Script" },
                    { 6, "C" },
                    { 7, "C++" },
                    { 8, "PHP" },
                    { 9, "Visual Basic" },
                    { 10, "Swift" },
                    { 11, "NodeJS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProgLanguage_LenId",
                table: "EmployeeProgLanguage",
                column: "LenId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CurrentDepartmentId",
                table: "Employees",
                column: "CurrentDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProgLanguage");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
