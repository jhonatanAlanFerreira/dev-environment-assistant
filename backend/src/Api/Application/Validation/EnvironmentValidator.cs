using DeveloperEnvironmentAssistant.Api.Domain.Entities;

namespace DeveloperEnvironmentAssistant.Api.Application.Validation;

public static class EnvironmentValidator
{
    public static IReadOnlyList<string> Validate(EnvironmentConfiguration environment)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(environment.Name)) errors.Add("Environment name is required.");
        if (environment.Services.Count == 0) errors.Add("At least one service definition is required.");
        if (environment.Services.GroupBy(item => item.Name, StringComparer.OrdinalIgnoreCase).Any(group => group.Count() > 1))
            errors.Add("Service names must be unique within an environment.");
        if (environment.Services.GroupBy(item => item.Port).Any(group => group.Count() > 1))
            errors.Add("Service ports must be unique within an environment.");
        return errors;
    }
}