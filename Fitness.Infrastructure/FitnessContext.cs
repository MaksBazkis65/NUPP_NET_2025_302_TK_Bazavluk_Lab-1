using Microsoft.EntityFrameworkCore;
using Fitness.Infrastructure.Models;

namespace Fitness.Infrastructure
{
    public class FitnessContext : DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options)
        {
        }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<WorkoutModel> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientModel>()
                .HasMany(c => c.Workouts)
                .WithOne(w => w.Client)
                .HasForeignKey(w => w.ClientId);
        }
    }
}