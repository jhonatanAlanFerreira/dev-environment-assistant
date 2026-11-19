using DeveloperEnvironmentAssistant.Api.Domain.Enums;

namespace DeveloperEnvironmentAssistant.Api.Domain.Entities;

public sealed class Service
{
    public Guid Id { get; set; }
    public Guid EnvironmentConfigurationId { get; set; }
    public EnvironmentConfiguration? EnvironmentConfiguration { get; set; }
    public string Name { get; set; } = string.Empty;
    public ServiceStatus Status { get; set; } = ServiceStatus.Unknown;
    public string Host { get; set; } = "localhost";
    public int Port { get; set; }
    public string DependencyIdsJson { get; set; } = "[]";
    public string Notes { get; set; } = string.Empty;
    public List<CheckResult> CheckResults { get; set; } = [];
}