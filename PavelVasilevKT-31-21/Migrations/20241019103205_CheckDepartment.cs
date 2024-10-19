using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavelVasilevKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CheckDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Department_DepartmentId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_Department_department_id",
                table: "Departments",
                newName: "IX_Departments_department_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_department_id",
                table: "Department",
                newName: "IX_Department_department_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Department_DepartmentId",
                table: "Teachers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "department_id");
        }
    }
}
