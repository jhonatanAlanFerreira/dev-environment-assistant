namespace DeveloperEnvironmentAssistant.Api.Domain.Entities;

public sealed class KnownProblem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Solution { get; set; } = string.Empty;
    public string Status { get; set; } = "documented";
    public string RelatedServicesJson { get; set; } = "[]";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}