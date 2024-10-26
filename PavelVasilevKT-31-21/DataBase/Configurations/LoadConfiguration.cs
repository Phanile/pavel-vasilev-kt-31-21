using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PavelVasilevKT_31_21.DataBase.Helpers;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.DataBase.Configurations
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        private const string TableName = "cd_loads";

        public void Configure(EntityTypeBuilder<Load> builder)
        {
            builder
                .HasKey(load => load.Id)
                .HasName($"pk_{TableName}_load_id");

            builder.Property(load => load.Id).ValueGeneratedOnAdd();
            builder.HasIndex(load => load.Id);

            builder.ToTable(TableName).HasIndex(load => load.TeacherId, $"idx_{TableName}_fk_f_teacher_id");
            builder.ToTable(TableName).HasIndex(load => load.DisciplineId, $"idx_{TableName}_fk_f_discipline_id");


            builder.Property(load => load.TeacherId)
                .IsRequired()
                .HasColumnName("teacher_id")
                .HasColumnType(ColumnTypeHelper.Int)
                .HasComment("Идентификатор преподавателя");

            builder.Property(load => load.DisciplineId)
                .IsRequired()
                .HasColumnName("discipline_id")
                .HasColumnType(ColumnTypeHelper.Int)
                .HasComment("Идентификатор дисциплины");


            builder.Property(load => load.LoadInHours)
                .IsRequired()
                .HasColumnName("load_in_hours")
                .HasColumnType(ColumnTypeHelper.Int)
                .HasComment("Продолжительность дисциплины в часах");

            builder.Navigation(load => load.Teacher).AutoInclude();
            builder.Navigation(load => load.Discipline).AutoInclude();

            builder
                .ToTable(TableName)
                .HasOne(load => load.Teacher)
                .WithMany()
                .HasForeignKey(load => load.TeacherId)
                .HasConstraintName("fk_f_teacher_id");

            builder
                .ToTable(TableName)
                .HasOne(load => load.Discipline)
                .WithMany()
                .HasForeignKey(load => load.DisciplineId)
                .HasConstraintName("fk_f_discipline_id");
        }
    }
}
