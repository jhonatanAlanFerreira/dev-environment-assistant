using DeveloperEnvironmentAssistant.Api.Domain.Enums;

namespace DeveloperEnvironmentAssistant.Api.Application.Environments;

public sealed record ServiceReadModel(Guid Id, string Name, ServiceStatus Status, string Host, int Port, string[] DependencyIds, string Notes);
public sealed record EnvironmentReadModel(Guid Id, string Name, string[] LocalCodebasePaths, string[] TestUrls, IReadOnlyList<ServiceReadModel> Services, DateTime UpdatedAt);