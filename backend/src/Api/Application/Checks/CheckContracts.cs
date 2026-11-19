using DeveloperEnvironmentAssistant.Api.Domain.Enums;

namespace DeveloperEnvironmentAssistant.Api.Application.Checks;

public sealed record CheckExecutionRequest(Guid EnvironmentId);
public sealed record CheckResultReadModel(Guid Id, Guid? ServiceId, string ServiceName, CheckType CheckType, CheckStatus Status, string Output, DateTime Timestamp);
public sealed record CheckRunReadModel(Guid RunId, IReadOnlyList<CheckResultReadModel> ServiceResults, string Summary, DateTime Timestamp);

public interface IEnvironmentCheck
{
    CheckType Type { get; }
    Task<(CheckStatus Status, string Output)> RunAsync(string host, int port, string serviceName, CancellationToken cancellationToken);
}