using Microsoft.EntityFrameworkCore;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Data
{
    public class VotingDbContext : DbContext
    {
        public VotingDbContext(DbContextOptions<VotingDbContext> options) : base(options) { }

        public DbSet<Resident> Residents { get; set; } = null!;
        public DbSet<Candidate> Candidates { get; set; } = null!;
        public DbSet<Election> Elections { get; set; } = null!;
        public DbSet<Vote> Votes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resident>().ToTable("Resident");
            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<Election>().ToTable("Election");
            modelBuilder.Entity<Vote>().ToTable("Vote");

            // Configure relationships for Election
            modelBuilder.Entity<Election>()
                .HasOne(e => e.CandidateAEntity)
                .WithMany(c => c.ElectionAsCandidateA)
                .HasForeignKey(e => e.CandidateA)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Election>()
                .HasOne(e => e.CandidateBEntity)
                .WithMany(c => c.ElectionAsCandidateB)
                .HasForeignKey(e => e.CandidateB)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Vote
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Resident)
                .WithMany(r => r.Votes)
                .HasForeignKey(v => v.ResidentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Election)
                .WithMany(e => e.Votes)
                .HasForeignKey(v => v.ElectionID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Candidate)
                .WithMany()
                .HasForeignKey(v => v.CandidateID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vote>()
                .HasIndex(v => new { v.ResidentID, v.ElectionID })
                .IsUnique();
        }
    }
}
