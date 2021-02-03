using Microsoft.EntityFrameworkCore;
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
: base(options) {

         
        }

     
        public DbSet<Student> Students { get; set; } 

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Teacher> Teachers { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Discipline>().HasMany(c => c.Students)
           .WithMany(s => s.Disciplines);
        




            //     modelBuilder.Entity<StudentDiscipline>()
            //    .HasKey(key => new { key.StudentId, key.DisciplineId });

            base.OnModelCreating(modelBuilder);
        }

     
    }
}
