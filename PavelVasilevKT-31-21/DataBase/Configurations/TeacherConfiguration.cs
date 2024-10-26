using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PavelVasilevKT_31_21.DataBase.Helpers;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.DataBase.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teachers";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(TableName);

            builder
                .HasKey(teacher => teacher.Id)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(teacher => teacher.Id).ValueGeneratedOnAdd();
            builder.HasIndex(teacher => teacher.Id);

            builder.Property(teacher => teacher.Name)
                .IsRequired()
                .HasColumnName("c_teacher_name")
                .HasColumnType(ColumnTypeHelper.String)
                .HasMaxLength(50)
                .HasComment("Имя преподавателя");

            builder.Property(teacher => teacher.Surname)
                .IsRequired()
                .HasColumnName("c_teacher_surname")
                .HasColumnType(ColumnTypeHelper.String)
                .HasMaxLength(50)
                .HasComment("Фамилия преподавателя");

            builder.Property(teacher => teacher.Patronymic)
                .IsRequired()
                .HasColumnName("c_teacher_patronymic")
                .HasColumnType(ColumnTypeHelper.String)
                .HasMaxLength(50)
                .HasComment("Отчество преподавателя");

            builder.Navigation(teacher => teacher.Disciplines).AutoInclude();
            builder.Navigation(teacher => teacher.Department).AutoInclude();
        }
    }
}
