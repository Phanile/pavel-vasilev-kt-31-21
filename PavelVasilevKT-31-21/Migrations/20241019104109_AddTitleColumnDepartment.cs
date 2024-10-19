using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavelVasilevKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleColumnDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Departments",
                newName: "c_department_title");

            migrationBuilder.AlterColumn<string>(
                name: "c_department_title",
                table: "Departments",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                comment: "Название кафедры",
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_department_title",
                table: "Departments",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Departments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldComment: "Название кафедры");
        }
    }
}
