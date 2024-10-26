using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PavelVasilevKT_31_21.DataBase.Helpers;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.DataBase.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_disciplines";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(TableName);
            
            builder
                .HasKey(discipline => discipline.Id)
                .HasName($"pk_{TableName}_discipline_id");

            builder.Property(discipline => discipline.Id).ValueGeneratedOnAdd();
            builder.HasIndex(discipline => discipline.Id);

            builder.Property(discipline => discipline.Title)
                .IsRequired()
                .HasColumnName("c_discipline_title")
                .HasColumnType(ColumnTypeHelper.String)
                .HasMaxLength(50)
                .HasComment("Название дисциплины");
        }
    }
}
