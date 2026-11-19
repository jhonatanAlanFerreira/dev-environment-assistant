using System.Text.RegularExpressions;

namespace DeveloperEnvironmentAssistant.Api.Application.Security;

public sealed partial class RedactionService
{
    [GeneratedRegex("(?i)(password|api[-_]?key|token|secret)(\\s*[:=]\\s*)[^\\s,;]+")]
    private static partial Regex SecretPattern();

    public string Sanitize(string? value) => string.IsNullOrWhiteSpace(value)
        ? string.Empty
        : SecretPattern().Replace(value, "$1$2[REDACTED]");
}