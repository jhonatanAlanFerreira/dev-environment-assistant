using System.Diagnostics;
using DeveloperEnvironmentAssistant.Api.Application.Checks;
using DeveloperEnvironmentAssistant.Api.Domain.Enums;

namespace DeveloperEnvironmentAssistant.Api.Infrastructure.Diagnostics;

public sealed class DockerServiceCheck : IEnvironmentCheck
{
    public CheckType Type => CheckType.Health;

    public async Task<(CheckStatus Status, string Output)> RunAsync(string host, int port, string serviceName, CancellationToken cancellationToken)
    {
        try
        {
            using var process = Process.Start(new ProcessStartInfo
            {
                FileName = "docker",
                Arguments = $"ps --filter name={serviceName} --format {{\"{{.Names}}\"}}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });
            if (process is null) return (CheckStatus.Warning, "Docker CLI is unavailable.");
            var output = await process.StandardOutput.ReadToEndAsync(cancellationToken);
            await process.WaitForExitAsync(cancellationToken);
            return string.IsNullOrWhiteSpace(output)
                ? (CheckStatus.Fail, $"Container '{serviceName}' is not running.")
                : (CheckStatus.Pass, $"Container '{serviceName}' is running.");
        }
        catch (Exception exception) when (exception is InvalidOperationException or System.ComponentModel.Win32Exception)
        {
            return (CheckStatus.Warning, "Docker CLI is unavailable; container status could not be checked.");
        }
    }
}