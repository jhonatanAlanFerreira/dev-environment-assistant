using DeveloperEnvironmentAssistant.Api.Application.Checks;
using DeveloperEnvironmentAssistant.Api.Domain.Enums;

namespace DeveloperEnvironmentAssistant.Api.Infrastructure.Diagnostics;

public sealed class HttpEndpointCheck(IHttpClientFactory httpClientFactory) : IEnvironmentCheck
{
    public CheckType Type => CheckType.Endpoint;

    public async Task<(CheckStatus Status, string Output)> RunAsync(string host, int port, string serviceName, CancellationToken cancellationToken)
    {
        try
        {
            using var response = await httpClientFactory.CreateClient().GetAsync($"http://{host}:{port}/health", cancellationToken);
            return response.IsSuccessStatusCode
                ? (CheckStatus.Pass, $"Health endpoint for '{serviceName}' returned {(int)response.StatusCode}.")
                : (CheckStatus.Fail, $"Health endpoint for '{serviceName}' returned {(int)response.StatusCode}.");
        }
        catch (HttpRequestException)
        {
            return (CheckStatus.Fail, $"Health endpoint for '{serviceName}' is unreachable.");
        }
    }
}