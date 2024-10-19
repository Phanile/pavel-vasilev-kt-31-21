﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PavelVasilevKT_31_21.DataBase;

#nullable disable

namespace PavelVasilevKT_31_21.Migrations
{
    [DbContext(typeof(TeachersDbContext))]
    [Migration("20241019104109_AddTitleColumnDepartment")]
    partial class AddTitleColumnDepartment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PavelVasilevKT_31_21.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int4")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор кафедры");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HeadId")
                        .HasColumnType("int4")
                        .HasColumnName("head_id")
                        .HasComment("Идентификатор заведующего кафедры");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("c_department_title")
                        .HasComment("Название кафедры");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("PavelVasilevKT_31_21.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("TeacherId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("c_discipline_title")
                        .HasComment("Название дисциплины");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("PavelVasilevKT_31_21.Models.Load", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int4")
                        .HasColumnName("discipline_id")
                        .HasComment("Идентификатор дисциплины");

                    b.Property<int>("LoadInHours")
                        .HasColumnType("int4")
                        .HasColumnName("load_in_hours")
                        .HasComment("Продолжительность дисциплины в часах");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int4")
                        .HasColumnName("teacher_id")
                        .HasComment("Идентификатор преподавателя");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Loads");
                });

            modelBuilder.Entity("PavelVasilevKT_31_21.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_name")
                        .HasComment("Имя преподавателя");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_patronymic")
                        .HasComment("Отчество преподавателя");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_surname")
                        .HasComment("Фамилия преподавателя");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("PavelVasilevKT_31_21.Models.Discipline", b =>
                {
                    b.HasOne("PavelVasilevKT_31_21.Models.Teacher", null)
                        .WithMany("Disciplines")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("PavelVasilevKT_31_21.Models.Load", b =>
                {
                    b.HasOne("PavelVasilevKT_31_21.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PavelVasilevKT_31_21.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PavelVasilevKT_31_21.Models.Teacher", b =>
                {
                    b.HasOne("PavelVasilevKT_31_21.Models.Department", null)
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("PavelVasilevKT_31_21.Models.Department", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("PavelVasilevKT_31_21.Models.Teacher", b =>
                {
                    b.Navigation("Disciplines");
                });
#pragma warning restore 612, 618
        }
    }
}
