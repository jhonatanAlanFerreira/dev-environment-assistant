namespace DeveloperEnvironmentAssistant.Api.Application.Security;

public sealed class RedactionPolicy(RedactionService redactionService)
{
    public string SanitizeDiagnostic(string? value) => redactionService.Sanitize(value);
}