using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavelVasilevKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class DBTableNamesChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "cd_teachers");

            migrationBuilder.RenameTable(
                name: "Disciplines",
                newName: "cd_disciplines");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "cd_departments");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_Id",
                table: "cd_teachers",
                newName: "IX_cd_teachers_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_DepartmentId",
                table: "cd_teachers",
                newName: "IX_cd_teachers_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplines_TeacherId",
                table: "cd_disciplines",
                newName: "IX_cd_disciplines_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplines_Id",
                table: "cd_disciplines",
                newName: "IX_cd_disciplines_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_department_id",
                table: "cd_departments",
                newName: "IX_cd_departments_department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_disciplines_cd_teachers_TeacherId",
                table: "cd_disciplines",
                column: "TeacherId",
                principalTable: "cd_teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_teachers_cd_departments_DepartmentId",
                table: "cd_teachers",
                column: "DepartmentId",
                principalTable: "cd_departments",
                principalColumn: "department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_disciplines_cd_teachers_TeacherId",
                table: "cd_disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_cd_teachers_cd_departments_DepartmentId",
                table: "cd_teachers");

            migrationBuilder.RenameTable(
                name: "cd_teachers",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "cd_disciplines",
                newName: "Disciplines");

            migrationBuilder.RenameTable(
                name: "cd_departments",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_cd_teachers_Id",
                table: "Teachers",
                newName: "IX_Teachers_Id");

            migrationBuilder.RenameIndex(
                name: "IX_cd_teachers_DepartmentId",
                table: "Teachers",
                newName: "IX_Teachers_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_cd_disciplines_TeacherId",
                table: "Disciplines",
                newName: "IX_Disciplines_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_cd_disciplines_Id",
                table: "Disciplines",
                newName: "IX_Disciplines_Id");

            migrationBuilder.RenameIndex(
                name: "IX_cd_departments_department_id",
                table: "Departments",
                newName: "IX_Departments_department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "department_id");
        }
    }
}
