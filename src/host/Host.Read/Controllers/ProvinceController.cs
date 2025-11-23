using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Queries.Province;
using Service.Response.Province;

namespace Host.Read;

[ApiController]
[Route("api/v1/province")]
public class ProvinceController(IMediator _mediator) : ControllerBase
{
    /// <summary>
    /// Finds a province by it's Id
    /// </summary>
    /// <param name="id">The Id of the province</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(Result<ProvinceDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result);
    }

    /// <summary>
    /// Finds provinces by name or code
    /// </summary>
    /// <param name="code">The Code of the province</param>
    /// <param name="name">The Name of the province</param>
    /// <returns></returns>
    [HttpGet("provinces")]
    [ProducesResponseType(typeof(Result<List<ProvinceDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync([FromQuery] GetQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result);
    }
}