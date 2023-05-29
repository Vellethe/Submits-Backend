using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrainingProject.Models;

namespace TrainingProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountData> AccountData { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExecise> WorkoutExecises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasOne(e=> e.Workout)
                .WithMany(e=>e.Ratings)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
