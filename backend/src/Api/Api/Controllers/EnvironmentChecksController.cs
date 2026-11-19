using DeveloperEnvironmentAssistant.Api.Application.Checks;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperEnvironmentAssistant.Api.Api.Controllers;

[ApiController]
[Route("api/environments/{environmentId:guid}/checks")]
public sealed class EnvironmentChecksController(EnvironmentCheckService checkService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CheckRunReadModel>> Run(Guid environmentId, CancellationToken cancellationToken)
    {
        var result = await checkService.RunAsync(environmentId, cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }
}