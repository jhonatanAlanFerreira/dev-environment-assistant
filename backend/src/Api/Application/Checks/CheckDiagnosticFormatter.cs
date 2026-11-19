using DeveloperEnvironmentAssistant.Api.Application.Security;
using DeveloperEnvironmentAssistant.Api.Domain.Enums;

namespace DeveloperEnvironmentAssistant.Api.Application.Checks;

public sealed class CheckDiagnosticFormatter(RedactionPolicy redactionPolicy)
{
    public string Format(CheckStatus status, string output) => redactionPolicy.SanitizeDiagnostic(status == CheckStatus.Fail
        ? $"Failure detected. Review the configured dependency and endpoint. {output}"
        : output);
}