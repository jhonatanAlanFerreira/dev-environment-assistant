using System.Net.Sockets;
using DeveloperEnvironmentAssistant.Api.Application.Checks;
using DeveloperEnvironmentAssistant.Api.Domain.Enums;

namespace DeveloperEnvironmentAssistant.Api.Infrastructure.Diagnostics;

public sealed class DependencyConnectivityCheck : IEnvironmentCheck
{
    public CheckType Type => CheckType.Connectivity;

    public async Task<(CheckStatus Status, string Output)> RunAsync(string host, int port, string serviceName, CancellationToken cancellationToken)
    {
        using var client = new TcpClient();
        try
        {
            await client.ConnectAsync(host, port, cancellationToken);
            return (CheckStatus.Pass, $"'{serviceName}' accepted a TCP connection.");
        }
        catch (SocketException)
        {
            return (CheckStatus.Fail, $"'{serviceName}' did not accept a TCP connection.");
        }
    }
}