using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PavelVasilevKT_31_21.DataBase.Helpers;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.DataBase.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(department => department.Id);
            builder.HasIndex(department => department.Id);

            builder.Property(department => department.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("department_id")
                .HasColumnType(ColumnTypeHelper.Int)
                .HasComment("Идентификатор кафедры");

            builder.Property(department => department.HeadId)
                .IsRequired()
                .HasColumnName("head_id")
                .HasColumnType(ColumnTypeHelper.Int)
                .HasComment("Идентификатор заведующего кафедры");

            builder.Property(department => department.Title)
                .IsRequired()
                .HasColumnName("c_department_title")
                .HasColumnType(ColumnTypeHelper.String)
                .HasMaxLength(50)
                .HasComment("Название кафедры");

            builder.Navigation(department => department.Teachers).AutoInclude();
        }
    }
}
