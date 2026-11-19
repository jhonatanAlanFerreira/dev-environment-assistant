using System.Text.Json;
using DeveloperEnvironmentAssistant.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEnvironmentAssistant.Api.Application.Environments;

public sealed class EnvironmentQueryService(AssistantDbContext database)
{
    public async Task<EnvironmentReadModel?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var environment = await database.Environments.AsNoTracking().Include(item => item.Services)
            .SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        if (environment is null) return null;
        return new EnvironmentReadModel(environment.Id, environment.Name,
            JsonSerializer.Deserialize<string[]>(environment.LocalCodebasePathsJson) ?? [],
            JsonSerializer.Deserialize<string[]>(environment.TestUrlsJson) ?? [],
            environment.Services.Select(service => new ServiceReadModel(service.Id, service.Name, service.Status,
                service.Host, service.Port, JsonSerializer.Deserialize<string[]>(service.DependencyIdsJson) ?? [], service.Notes)).ToList(),
            environment.UpdatedAt);
    }
}