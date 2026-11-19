namespace DeveloperEnvironmentAssistant.Api.Domain.Entities;

public sealed class SolutionRecord
{
    public Guid Id { get; set; }
    public Guid IncidentId { get; set; }
    public Incident? Incident { get; set; }
    public string Summary { get; set; } = string.Empty;
    public string Status { get; set; } = "pending";
    public bool VerifiedByDeveloper { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}