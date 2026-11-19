namespace DeveloperEnvironmentAssistant.Api.Domain.Entities;

public sealed class Incident
{
    public Guid Id { get; set; }
    public Guid EnvironmentConfigurationId { get; set; }
    public Guid? ServiceId { get; set; }
    public string Symptoms { get; set; } = string.Empty;
    public string Status { get; set; } = "open";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ResolvedAt { get; set; }
    public List<SolutionRecord> Solutions { get; set; } = [];
}