using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavelVasilevKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class AutoIncludeDepartmentToTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_teachers_cd_departments_DepartmentId",
                table: "cd_teachers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "cd_teachers",
                type: "int4",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int4",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cd_teachers_cd_departments_DepartmentId",
                table: "cd_teachers",
                column: "DepartmentId",
                principalTable: "cd_departments",
                principalColumn: "department_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_teachers_cd_departments_DepartmentId",
                table: "cd_teachers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "cd_teachers",
                type: "int4",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int4");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_teachers_cd_departments_DepartmentId",
                table: "cd_teachers",
                column: "DepartmentId",
                principalTable: "cd_departments",
                principalColumn: "department_id");
        }
    }
}
