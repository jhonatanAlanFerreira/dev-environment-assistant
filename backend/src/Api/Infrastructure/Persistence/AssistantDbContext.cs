using DeveloperEnvironmentAssistant.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEnvironmentAssistant.Api.Infrastructure.Persistence;

public sealed class AssistantDbContext(DbContextOptions<AssistantDbContext> options) : DbContext(options)
{
    public DbSet<EnvironmentConfiguration> Environments => Set<EnvironmentConfiguration>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<CheckResult> CheckResults => Set<CheckResult>();
    public DbSet<KnownProblem> KnownProblems => Set<KnownProblem>();
    public DbSet<Incident> Incidents => Set<Incident>();
    public DbSet<SolutionRecord> SolutionRecords => Set<SolutionRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnvironmentConfiguration>().HasKey(item => item.Id);
        modelBuilder.Entity<EnvironmentConfiguration>().Property(item => item.Name).HasMaxLength(160).IsRequired();
        modelBuilder.Entity<EnvironmentConfiguration>().HasMany(item => item.Services)
            .WithOne(item => item.EnvironmentConfiguration).HasForeignKey(item => item.EnvironmentConfigurationId);
        modelBuilder.Entity<EnvironmentConfiguration>().HasMany(item => item.CheckResults)
            .WithOne().HasForeignKey(item => item.EnvironmentConfigurationId);
        modelBuilder.Entity<EnvironmentConfiguration>().HasMany(item => item.Incidents)
            .WithOne().HasForeignKey(item => item.EnvironmentConfigurationId);
        modelBuilder.Entity<Service>().HasKey(item => item.Id);
        modelBuilder.Entity<Service>().HasIndex(item => new { item.EnvironmentConfigurationId, item.Name }).IsUnique();
        modelBuilder.Entity<Service>().HasIndex(item => new { item.EnvironmentConfigurationId, item.Port }).IsUnique();
        modelBuilder.Entity<CheckResult>().HasKey(item => item.Id);
        modelBuilder.Entity<KnownProblem>().HasKey(item => item.Id);
        modelBuilder.Entity<Incident>().HasKey(item => item.Id);
        modelBuilder.Entity<Incident>().HasMany(item => item.Solutions)
            .WithOne(item => item.Incident).HasForeignKey(item => item.IncidentId);
        modelBuilder.Entity<SolutionRecord>().HasKey(item => item.Id);
    }
}