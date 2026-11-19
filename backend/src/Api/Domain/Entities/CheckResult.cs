using DeveloperEnvironmentAssistant.Api.Domain.Enums;

namespace DeveloperEnvironmentAssistant.Api.Domain.Entities;

public sealed class CheckResult
{
    public Guid Id { get; set; }
    public Guid EnvironmentConfigurationId { get; set; }
    public Guid? ServiceId { get; set; }
    public Service? Service { get; set; }
    public CheckType CheckType { get; set; }
    public CheckStatus Status { get; set; }
    public string Output { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}