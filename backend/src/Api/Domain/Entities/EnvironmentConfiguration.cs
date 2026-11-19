namespace DeveloperEnvironmentAssistant.Api.Domain.Entities;

public sealed class EnvironmentConfiguration
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Owner { get; set; } = "local-developer";
    public string LocalCodebasePathsJson { get; set; } = "[]";
    public string TestUrlsJson { get; set; } = "[]";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<Service> Services { get; set; } = [];
    public List<CheckResult> CheckResults { get; set; } = [];
    public List<Incident> Incidents { get; set; } = [];
}