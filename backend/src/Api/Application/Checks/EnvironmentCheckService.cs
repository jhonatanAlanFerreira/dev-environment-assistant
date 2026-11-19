using DeveloperEnvironmentAssistant.Api.Domain.Entities;
using DeveloperEnvironmentAssistant.Api.Infrastructure.Diagnostics;
using DeveloperEnvironmentAssistant.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEnvironmentAssistant.Api.Application.Checks;

public sealed class EnvironmentCheckService(
    AssistantDbContext database,
    CheckDiagnosticFormatter formatter,
    DockerServiceCheck dockerCheck,
    HttpEndpointCheck endpointCheck,
    DependencyConnectivityCheck connectivityCheck)
{
    public async Task<CheckRunReadModel?> RunAsync(Guid environmentId, CancellationToken cancellationToken)
    {
        var environment = await database.Environments.Include(item => item.Services)
            .SingleOrDefaultAsync(item => item.Id == environmentId, cancellationToken);
        if (environment is null) return null;
        var results = new List<CheckResult>();
        foreach (var service in environment.Services)
        {
            var checks = service.Name.Contains("api", StringComparison.OrdinalIgnoreCase)
                ? new IEnvironmentCheck[] { dockerCheck, endpointCheck }
                : new IEnvironmentCheck[] { dockerCheck, connectivityCheck };
            foreach (var check in checks)
            {
                var result = await check.RunAsync(service.Host, service.Port, service.Name, cancellationToken);
                results.Add(new CheckResult
                {
                    Id = Guid.NewGuid(), EnvironmentConfigurationId = environment.Id, ServiceId = service.Id,
                    CheckType = check.Type, Status = result.Status, Output = formatter.Format(result.Status, result.Output), Timestamp = DateTime.UtcNow
                });
            }
        }
        database.CheckResults.AddRange(results);
        await database.SaveChangesAsync(cancellationToken);
        var readResults = results.Select(result => new CheckResultReadModel(result.Id, result.ServiceId,
            environment.Services.First(service => service.Id == result.ServiceId).Name, result.CheckType,
            result.Status, result.Output, result.Timestamp)).ToList();
        var failures = readResults.Count(result => result.Status == Domain.Enums.CheckStatus.Fail);
        return new CheckRunReadModel(Guid.NewGuid(), readResults,
            failures == 0 ? "All configured checks passed or returned warnings." : $"{failures} check(s) failed and need attention.", DateTime.UtcNow);
    }
}