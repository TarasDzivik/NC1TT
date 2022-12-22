using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NC1TestTask.Migrations
{
    /// <inheritdoc />
    public partial class AddedMtoMRelationshipbetweenProgLangandEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ProgrammingLanguages_EmployeeId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingLanguagePLId",
                table: "Employees",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProgrammingLanguagePLId",
                table: "Employees",
                column: "ProgrammingLanguagePLId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProgLanguage_LenId",
                table: "EmployeeProgLanguage",
                column: "LenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ProgrammingLanguages_ProgrammingLanguagePLId",
                table: "Employees",
                column: "ProgrammingLanguagePLId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "PLId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ProgrammingLanguages_ProgrammingLanguagePLId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeProgLanguage");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProgrammingLanguagePLId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguagePLId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ProgrammingLanguages_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "PLId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
