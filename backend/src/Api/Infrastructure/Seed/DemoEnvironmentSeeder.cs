using System.Text.Json;
using DeveloperEnvironmentAssistant.Api.Domain.Entities;
using DeveloperEnvironmentAssistant.Api.Domain.Enums;
using DeveloperEnvironmentAssistant.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEnvironmentAssistant.Api.Infrastructure.Seed;

public static class DemoEnvironmentSeeder
{
    public static async Task SeedAsync(AssistantDbContext database)
    {
        if (await database.Environments.AnyAsync()) return;
        var databaseServiceId = Guid.NewGuid();
        var environment = new EnvironmentConfiguration
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Local microservices demo",
            LocalCodebasePathsJson = JsonSerializer.Serialize(new[] { "C:/projects/demo" }),
            TestUrlsJson = JsonSerializer.Serialize(new[] { "http://localhost:8080/health" }),
            Services =
            [
                new Service { Id = databaseServiceId, Name = "mysql", Host = "localhost", Port = 3307, Status = ServiceStatus.Unknown },
                new Service { Id = Guid.NewGuid(), Name = "catalog-api", Host = "localhost", Port = 8080, Status = ServiceStatus.Unknown, DependencyIdsJson = JsonSerializer.Serialize(new[] { databaseServiceId.ToString() }) }
            ]
        };
        database.Environments.Add(environment);
        await database.SaveChangesAsync();
    }
}