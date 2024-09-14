using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.DataBase.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(teacher => teacher.Id);
            builder.Property(teacher => teacher.Id).ValueGeneratedOnAdd();
            builder.HasIndex(teacher => teacher.Id);

            builder.Navigation(teacher => teacher.Disciplines).AutoInclude();
            builder.HasMany(teacher => teacher.Disciplines);
            builder.Property(teacher => teacher.FullName).IsRequired();
        }
    }
}
