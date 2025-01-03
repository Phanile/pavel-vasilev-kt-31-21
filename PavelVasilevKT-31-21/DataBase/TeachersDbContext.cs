﻿using Microsoft.EntityFrameworkCore;
using PavelVasilevKT_31_21.DataBase.Configurations;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.DataBase
{
	public class TeachersDbContext : DbContext
	{
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Department> Departments { get; set; }

        public TeachersDbContext(DbContextOptions<TeachersDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new LoadConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }
    }
}
