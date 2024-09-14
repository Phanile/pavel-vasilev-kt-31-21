using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.DataBase.Configurations
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        public void Configure(EntityTypeBuilder<Load> builder)
        {
            builder.HasKey(load => load.Id);
            builder.Property(load => load.Id).ValueGeneratedOnAdd();
            builder.HasIndex(load => load.Id);

            builder.Property(load => load.TeacherId).IsRequired();
            builder.Property(load => load.DisciplineId).IsRequired();
            builder.Property(load => load.LoadInHours).IsRequired();

            builder.Navigation(load => load.Teacher).AutoInclude();
            builder.Navigation(load => load.Discipline).AutoInclude();

            builder.HasOne(load => load.Teacher);
            builder.HasOne(load => load.Discipline);
        }
    }
}
