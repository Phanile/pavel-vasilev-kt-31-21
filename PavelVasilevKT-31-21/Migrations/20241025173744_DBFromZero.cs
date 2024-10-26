using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PavelVasilevKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class DBFromZero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    head_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор заведующего кафедры"),
                    c_department_title = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Название кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_departments_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Имя преподавателя"),
                    c_teacher_surname = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_patronymic = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Отчество преподавателя"),
                    DepartmentId = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teachers_teacher_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "department_id");
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_title = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Название дисциплины"),
                    TeacherId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_disciplines_discipline_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "cd_loads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    teacher_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор преподавателя"),
                    discipline_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор дисциплины"),
                    load_in_hours = table.Column<int>(type: "int4", nullable: false, comment: "Продолжительность дисциплины в часах")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_loads_load_id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.discipline_id,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_loads_fk_f_discipline_id",
                table: "cd_loads",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_loads_fk_f_teacher_id",
                table: "cd_loads",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_loads_Id",
                table: "cd_loads",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_department_id",
                table: "Departments",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_Id",
                table: "Disciplines",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TeacherId",
                table: "Disciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DepartmentId",
                table: "Teachers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Id",
                table: "Teachers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_loads");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
