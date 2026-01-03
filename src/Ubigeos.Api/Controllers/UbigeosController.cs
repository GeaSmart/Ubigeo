using Microsoft.AspNetCore.Mvc;
using Ubigeos.Application;

namespace Ubigeos.Api.Controllers;

[ApiController]
[Route("api/ubigeos")]
public class UbigeosController(IUbigeosService ubigeosService) : ControllerBase
{

    /// <summary>
    /// Obtiene los ubigeos hijos de un ubigeo padre.
    /// </summary>
    /// <param name="parentId">Id del ubigeo padre</param>
    [HttpGet("{parentId:int}/children")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByParent(
        int parentId,
        CancellationToken cancellationToken)
    {
        var result = await ubigeosService.GetByParentAsync(
            parentId,
            cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Obtiene el árbol completo de ubigeos (Departamentos → Provincias → Distritos).
    /// </summary>
    [HttpGet("tree")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTree(
        CancellationToken cancellationToken)
    {
        var result = await ubigeosService.GetTreeAsync(cancellationToken);

        return Ok(result);
    }
}