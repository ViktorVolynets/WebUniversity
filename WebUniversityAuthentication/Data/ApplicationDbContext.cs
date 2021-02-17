using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebUniversityAuthentication.Models;

namespace WebUniversityAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext<Student>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }



        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Teacher> Teachers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Discipline>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Students)
                .WithMany(s => s.Disciplines);

            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder
           .UseLazyLoadingProxies();



    }



}
