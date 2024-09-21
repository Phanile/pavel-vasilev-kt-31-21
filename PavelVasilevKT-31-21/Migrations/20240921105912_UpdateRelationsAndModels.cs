using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavelVasilevKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationsAndModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Teachers_HeadId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Disciplines_DisciplineId",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Teachers_TeacherId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Loads",
                newName: "teacher_id");

            migrationBuilder.RenameColumn(
                name: "LoadInHours",
                table: "Loads",
                newName: "load_in_hours");

            migrationBuilder.RenameColumn(
                name: "DisciplineId",
                table: "Loads",
                newName: "discipline_id");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_TeacherId",
                table: "Loads",
                newName: "IX_Loads_teacher_id");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_DisciplineId",
                table: "Loads",
                newName: "IX_Loads_discipline_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Disciplines",
                newName: "c_discipline_title");

            migrationBuilder.RenameColumn(
                name: "HeadId",
                table: "Department",
                newName: "department_id");

            migrationBuilder.RenameIndex(
                name: "IX_Department_HeadId",
                table: "Department",
                newName: "IX_Department_department_id");

            migrationBuilder.AddColumn<string>(
                name: "c_teacher_name",
                table: "Teachers",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Имя преподавателя");

            migrationBuilder.AddColumn<string>(
                name: "c_teacher_patronymic",
                table: "Teachers",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Отчество преподавателя");

            migrationBuilder.AddColumn<string>(
                name: "c_teacher_surname",
                table: "Teachers",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Фамилия преподавателя");

            migrationBuilder.AlterColumn<int>(
                name: "teacher_id",
                table: "Loads",
                type: "int4",
                nullable: false,
                comment: "Идентификатор преподавателя",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "load_in_hours",
                table: "Loads",
                type: "int4",
                nullable: false,
                comment: "Продолжительность дисциплины в часах",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "discipline_id",
                table: "Loads",
                type: "int4",
                nullable: false,
                comment: "Идентификатор дисциплины",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "c_discipline_title",
                table: "Disciplines",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                comment: "Название дисциплины",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "department_id",
                table: "Department",
                type: "int4",
                nullable: false,
                comment: "Идентификатор кафедры",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Department",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Teachers_department_id",
                table: "Department",
                column: "department_id",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Disciplines_discipline_id",
                table: "Loads",
                column: "discipline_id",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Teachers_teacher_id",
                table: "Loads",
                column: "teacher_id",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Teachers_department_id",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Disciplines_discipline_id",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Teachers_teacher_id",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "c_teacher_name",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "c_teacher_patronymic",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "c_teacher_surname",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "teacher_id",
                table: "Loads",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "load_in_hours",
                table: "Loads",
                newName: "LoadInHours");

            migrationBuilder.RenameColumn(
                name: "discipline_id",
                table: "Loads",
                newName: "DisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_teacher_id",
                table: "Loads",
                newName: "IX_Loads_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Loads_discipline_id",
                table: "Loads",
                newName: "IX_Loads_DisciplineId");

            migrationBuilder.RenameColumn(
                name: "c_discipline_title",
                table: "Disciplines",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "department_id",
                table: "Department",
                newName: "HeadId");

            migrationBuilder.RenameIndex(
                name: "IX_Department_department_id",
                table: "Department",
                newName: "IX_Department_HeadId");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Loads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Идентификатор преподавателя");

            migrationBuilder.AlterColumn<int>(
                name: "LoadInHours",
                table: "Loads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Продолжительность дисциплины в часах");

            migrationBuilder.AlterColumn<int>(
                name: "DisciplineId",
                table: "Loads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Идентификатор дисциплины");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Disciplines",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldComment: "Название дисциплины");

            migrationBuilder.AlterColumn<int>(
                name: "HeadId",
                table: "Department",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Идентификатор кафедры");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Teachers_HeadId",
                table: "Department",
                column: "HeadId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Disciplines_DisciplineId",
                table: "Loads",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Teachers_TeacherId",
                table: "Loads",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
