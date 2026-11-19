using DeveloperEnvironmentAssistant.Api.Application.Checks;
using DeveloperEnvironmentAssistant.Api.Application.Environments;
using DeveloperEnvironmentAssistant.Api.Application.Security;
using DeveloperEnvironmentAssistant.Api.Infrastructure.Persistence;
using DeveloperEnvironmentAssistant.Api.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddOpenApi();
builder.Services.AddCors(options => options.AddPolicy("local-ui", policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<AssistantDbContext>(options =>
    options.UseInMemoryDatabase("developer-environment-assistant"));

builder.Services.AddScoped<EnvironmentQueryService>();
builder.Services.AddScoped<EnvironmentCheckService>();
builder.Services.AddScoped<CheckDiagnosticFormatter>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<DeveloperEnvironmentAssistant.Api.Infrastructure.Diagnostics.DockerServiceCheck>();
builder.Services.AddScoped<DeveloperEnvironmentAssistant.Api.Infrastructure.Diagnostics.HttpEndpointCheck>();
builder.Services.AddScoped<DeveloperEnvironmentAssistant.Api.Infrastructure.Diagnostics.DependencyConnectivityCheck>();
builder.Services.AddSingleton<RedactionService>();
builder.Services.AddSingleton<RedactionPolicy>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var database = scope.ServiceProvider.GetRequiredService<AssistantDbContext>();
    await database.Database.EnsureCreatedAsync();
    await DemoEnvironmentSeeder.SeedAsync(database);
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("local-ui");
app.UseAuthorization();
app.MapControllers();

app.Run();
