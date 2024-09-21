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
            builder.Property(department => department.Id).ValueGeneratedOnAdd();
            builder.HasIndex(department => department.Id);

            builder.Property(department => department.HeadId)
                .IsRequired()
                .HasColumnName("department_id")
                .HasColumnType(ColumnTypeHelper.Int)
                .HasComment("Идентификатор кафедры");

            builder.Navigation(department => department.Head).AutoInclude();

            builder.HasOne(department => department.Head);
        }
    }
}
