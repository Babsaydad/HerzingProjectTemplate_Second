using HerzingProjectTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System;

namespace HerzingProjectTemplate.Data
{
    public class ApplicationDbContext2 : DbContext
    {
        public ApplicationDbContext2(DbContextOptions<ApplicationDbContext2> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<WorkOut> WorkOuts { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Rank> Ranks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Nutrition>()
                .HasOne(n => n.UserProfile)
                .WithMany(u => u.Nutritions) // Ensure UserProfile has: public ICollection<Nutrition> Nutritions {get; set;}
                .HasForeignKey(n => n.UserId) // This forces EF to use UserId instead of creating UserId2
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkOut>()
                .HasOne(w => w.UserProfile)
                .WithMany(u => u.WorkOuts)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
