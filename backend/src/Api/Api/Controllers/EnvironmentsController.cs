using DeveloperEnvironmentAssistant.Api.Application.Environments;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperEnvironmentAssistant.Api.Api.Controllers;

[ApiController]
[Route("api/environments")]
public sealed class EnvironmentsController(EnvironmentQueryService environmentQueryService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EnvironmentReadModel>> Get(Guid id, CancellationToken cancellationToken)
    {
        var environment = await environmentQueryService.GetAsync(id, cancellationToken);
        return environment is null ? NotFound() : Ok(environment);
    }
}