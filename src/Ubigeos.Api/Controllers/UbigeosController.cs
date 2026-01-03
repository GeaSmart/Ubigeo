using Microsoft.AspNetCore.Mvc;
using Ubigeos.Application;

namespace Ubigeos.Api.Controllers;

[ApiController]
[Route("api/ubigeos")]
public class UbigeosController(IUbigeosService ubigeosService) : ControllerBase
{
    [HttpGet("{parentId:int}/children")]
    public async Task<IActionResult> GetByParent(
        int parentId,
        CancellationToken cancellationToken)
    {
        var result = await ubigeosService.GetByParentAsync(
            parentId,
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("tree")]
    public async Task<IActionResult> GetTree(
        CancellationToken cancellationToken)
    {
        var result = await ubigeosService.GetTreeAsync(cancellationToken);
        return Ok(result);
    }
}