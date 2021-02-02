﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUniversity.Models;


namespace WebUniversity
{
    public class MyDbContext : DbContext
    {
   
        public MyDbContext(DbContextOptions<MyDbContext> options)
: base(options) { }

     
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDiscipline> StudentDisciplines { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDiscipline> TeacherDisciplines { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TeacherDiscipline>()
                .HasKey(key => new { key.TeacherId, key.DisciplineId });
            modelBuilder.Entity<StudentDiscipline>()
    .HasKey(key => new { key.StudentId, key.DisciplineId });

            base.OnModelCreating(modelBuilder);
        }

     
    }
}
